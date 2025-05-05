using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
using System.Security.Principal;
using tests_mantis.Mantis;


namespace tests_mantis
{
    public class ApiSoapHelper : HelperBase
    {
        public ApiSoapHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account,ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjectsApiSoap(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            List<ProjectData> projectsList = new List<ProjectData>();

            Mantis.ProjectData[] projectListMantis = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (Mantis.ProjectData projectMantis in projectListMantis)
            {
                projectsList.Add(new ProjectData()
                {
                    Name = projectMantis.name,
                    Description = projectMantis.description,
                    Id = projectMantis.id
                });
            }
            return projectsList;
        }

        public void AddProjectSoapApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            Mantis.ProjectData projectMantis = new Mantis.ProjectData();
            projectMantis.name = project.Name;
            projectMantis.description = project.Description;

            client.mc_project_add(account.Name, account.Password, projectMantis);
        }

        public void DeleteProjectSoapApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            client.mc_project_delete(account.Name, account.Password, project.Id);
        }

    }
}

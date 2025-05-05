using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using Assert = NUnit.Framework.Assert;
//using NUnit.Framework.Legacy;
using System.Linq;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace tests_mantis
{
    [TestFixture]
    public class ProjectCreationTests : /*TestBase*/AuthTestBase
    {

        [Test]
        public void ApiSoapCreateProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Name = "ProjectName" + GenerateRandomString(25),
                Description = "Description" + GenerateRandomString(25)
            };
            List<ProjectData> oldProjectList = app.ApiSoap.GetAllProjectsApiSoap(account);

            app.ApiSoap.AddProjectSoapApi(account, project);

            List<ProjectData> newProjectList = app.ApiSoap.GetAllProjectsApiSoap(account);

            oldProjectList.Add(project);
            oldProjectList.Sort();
            newProjectList.Sort();
            Assert.AreEqual(oldProjectList, newProjectList);
        }

        [Test]
        public void CreateProjectTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "ProjectName" + GenerateRandomString(25),
                Description = "Description" + GenerateRandomString(25)
            };

            List<ProjectData> oldProjectList = app.ProjectManagementHelper.GetProjectList();

            app.ProjectManagementHelper.CreateProject(project);

            List<ProjectData> newProjectList = app.ProjectManagementHelper.GetProjectList();

            oldProjectList.Add(project);

            oldProjectList.Sort();
            newProjectList.Sort();
            Assert.AreEqual(oldProjectList, newProjectList);
            app.ProjectManagementHelper.LogoutMantis();
        }
    }
}

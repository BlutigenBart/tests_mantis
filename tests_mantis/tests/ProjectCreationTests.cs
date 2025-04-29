using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework.Legacy;
using System.Linq;
using System.Xml.Linq;

namespace tests_mantis
{
    [TestFixture]
    public class ProjectCreationTests : TestBase/*AuthTestBase*/
    {
        ProjectData project = new ProjectData();

        [Test]
        public void CreateProjectTest()
        {
            app.Auth.Login();

            app.ManagementMenuHelper.ConProjTab();

            List<ProjectData> oldProjectList = app.ProjectManagementHelper.GetProjectList();
            //ProjectData project = new ProjectData();

            app.ManagementMenuHelper.InitNewProject();
            string projectName = GenerateRandomString(20);
            ProjectData project = new ProjectData(projectName);
            app.ProjectManagementHelper.EnterName(project.ProjectName);
            app.ProjectManagementHelper.AddProject();

            //app.ProjectManagementHelper.Create(project);

            //app.ProjectManagementHelper.CreateProject();

            List<ProjectData> newProjectList = app.ProjectManagementHelper.GetProjectList();

            oldProjectList.Add(project);

            oldProjectList.Sort();
            newProjectList.Sort();
            Assert.AreEqual(oldProjectList, newProjectList);
            app.ProjectManagementHelper.ExitMantis();
        }
    }
}

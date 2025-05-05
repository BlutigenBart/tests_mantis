using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
//using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;
using System.Security.Cryptography;

namespace tests_mantis
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ApiSoapProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjectList = app.ApiSoap.GetAllProjectsApiSoap(account);

            if (oldProjectList.Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "NewProject" + GenerateRandomString(25),
                    Description = "Description" + GenerateRandomString(25)
                };
                app.ApiSoap.AddProjectSoapApi(account, project);
                oldProjectList = app.ApiSoap.GetAllProjectsApiSoap(account);
            }


            ProjectData toBeRemoved = oldProjectList[0];
            app.ApiSoap.DeleteProjectSoapApi(account, toBeRemoved);

            List<ProjectData> newProjectList = app.ApiSoap.GetAllProjectsApiSoap(account);

            oldProjectList.Remove(toBeRemoved);
            oldProjectList.Sort();
            newProjectList.Sort();

            Assert.AreEqual(oldProjectList, newProjectList);
        }

        [Test]
        public void ProjectRemovalTest()
        {
            app.ProjectManagementHelper.ConfirmProjectExists();
            List<ProjectData> oldProjectList = app.ProjectManagementHelper.GetProjectList();
            
            ProjectData toBeRemoved = oldProjectList[0];
            app.ProjectManagementHelper.DeleteProject(0);

            List<ProjectData> newProjectList = app.ProjectManagementHelper.GetProjectList();

            oldProjectList.Remove(toBeRemoved);
            oldProjectList.Sort();
            newProjectList.Sort();

            Assert.AreEqual(oldProjectList, newProjectList);
            app.ProjectManagementHelper.LogoutMantis();
        }
    }
}

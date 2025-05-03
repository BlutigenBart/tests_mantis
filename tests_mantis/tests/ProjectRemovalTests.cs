using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;

namespace tests_mantis
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {

        [Test]
        public void ProjectRemovalTest()
        {
            app.Auth.Login();

            app.ManagementMenuHelper.ConProjTab();
            app.ProjectManagementHelper.ConfirmProjectExists();

            List<ProjectData> oldProjectList = app.ProjectManagementHelper.GetProjectList();

            ProjectData ToBeRemoved = oldProjectList[0];
            app.ProjectManagementHelper.SelectProjectOne();
            app.ProjectManagementHelper.DeleteProject();
            app.ProjectManagementHelper.CommitDeleteProject();

            List<ProjectData> newProjectList = app.ProjectManagementHelper.GetProjectList();

            oldProjectList.Remove(ToBeRemoved);

            Assert.AreEqual(oldProjectList, newProjectList);
            app.ProjectManagementHelper.ExitMantis();
        }
    }
}

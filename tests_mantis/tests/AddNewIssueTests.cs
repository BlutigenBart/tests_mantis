using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace tests_mantis
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "3"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };

            app.ApiSoap.CreateNewIssue(account, project, issue);

        }
    }
}

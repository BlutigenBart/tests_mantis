using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;

namespace tests_mantis
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpLogin()
        {
            app.Auth.Login(new AccountData()
            {
                Name = "administrator",
                Password = "root"
            });
        }
    }
}

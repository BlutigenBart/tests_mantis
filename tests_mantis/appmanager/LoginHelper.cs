using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;

namespace tests_mantis
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            //driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.4/login_page.php");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value = 'Вход']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value = 'Вход']")).Click();
        }
    }
}

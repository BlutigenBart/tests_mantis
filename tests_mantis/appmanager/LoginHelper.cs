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

        public void Login()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.4/login_page.php");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value = 'Вход']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value = 'Вход']")).Click();
        }

        //public void Login(AccountData account)
        //{
        //    if (IsLoggedIn())
        //    {
        //        if (IsLoggedIn(account))
        //        {
        //            return;
        //        }

        //        Logout();
        //    }
        //    Type(By.Name("username"), account.Name);
        //    driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        //    Type(By.Name("password"), account.Password);
        //    driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        //}

        //public bool IsLoggedIn()
        //{
        //    driver.FindElement(By.XPath("//span[@class='user - info']")).Click();
        //    return IsElementPresent(By.PartialLinkText("logout_page.php"));
        //}

        //public bool IsLoggedIn(AccountData account)
        //{
        //    return IsLoggedIn()
        //        && GetLoggedUserName() == account.Name;
        //}

        //public string GetLoggedUserName()
        //{
        //    string text = driver.FindElement(By.XPath("//span[@class='user - info']")).Text;
        //    return text.Substring(1, text.Length - 2);
        //}

        //public void Logout()
        //{
        //    if (IsLoggedIn())
        //    {
        //        driver.FindElement(By.XPath("//span[@class='user - info']")).Click();
        //        driver.FindElement(By.PartialLinkText("logout_page.php")).Click();
        //    }
        //}
    }
}

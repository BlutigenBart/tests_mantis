using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.V133.Network;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace tests_mantis
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) {}

        public void Control()
        {
            driver.FindElement(By.CssSelector("i.fa.fa-gears.menu-icon")).Click();
        }
        public void ProjectsTab()
        {
            driver.FindElement(By.XPath("//li//a[contains(text(),'Управление проектами')]")).Click();
        }
        public void InitNewProject()
        {
            driver.FindElement(By.XPath("//button[@type = 'submit']")).Click();
        }

        public void ConProjTab()
        {
            Control();
            ProjectsTab();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.V133.Network;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace tests_mantis
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        /// <summary>
        /// Кнопка "Добавить проект" в окне "Добавление проекта"
        /// </summary>
        public void AddProject()
        {
            driver.FindElement(By.XPath("//input[@value = 'Добавить проект']")).Click();
        }

        public void SelectProject(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index+1) + "]/td/a")).Click();
        }

        public void DeleteSelectedProject()
        {
            driver.FindElement(By.XPath("//input[@class = 'btn btn-primary btn-sm btn-white btn-round']")).Click();
        }

        public void ConfirmDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@class = 'btn btn-primary btn-white btn-round']")).Click();
        }
        public List<ProjectData> GetProjectList()
        {
            manager.ManagementMenuHelper.GoToProjectTab();
            List<ProjectData> projects = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr/td/a"));

            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData()
                {
                    Name = element.Text
                });
            }
            return projects;
        }
        public bool IsProjectDetection()
        {
            // Проверка наличия хотя бы одного проекта на странице
            return IsElementPresent(By.XPath("//tr/td/a"));
        }

        public ProjectManagementHelper ConfirmProjectExists()
        {
            // Проверяем, есть ли хотя бы одна группа
            if (!IsProjectDetection())
            {
                //Переход на страницу создания проектов
                manager.ManagementMenuHelper.GoToProjectTab();
                //manager.ManagementMenuHelper.InitNewProject();
                // Если проектов нет, создает один
                ProjectData project = new ProjectData()
                {
                    Name = "ProjectName" + TestBase.GenerateRandomString(30),
                    Description = "Description" + TestBase.GenerateRandomString(30)

                };
                Create(project);  // Вызываем метод для создания группы
            }
            return this;
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.ManagementMenuHelper.GoToProjectTab();
            InitNewProjectCreation();
            FillProjectName(project);
            SubmitProjectCreation();
            Thread.Sleep(3000);
            return this;
        }

        public ProjectManagementHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type = 'submit']")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectName(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            return this;
        }
        /// <summary>
        /// Создание группы
        /// </summary>
        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value = 'Добавить проект']")).Click();
            return this;
        }

        public ProjectManagementHelper CreateProject(ProjectData project)
        {
            manager.ManagementMenuHelper.GoToProjectTab();
            InitNewProjectCreation();
            FillProjectName(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper DeleteProject(int i)
        {
            manager.ManagementMenuHelper.GoToProjectTab();
            SelectProject(i);
            DeleteSelectedProject();
            ConfirmDeleteProject();
            return this;
        }

        public void LogoutMantis()
        {
            driver.FindElement(By.XPath("//span[@class = 'user-info']")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }
    }
}

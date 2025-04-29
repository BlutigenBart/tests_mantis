using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.Network;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace tests_mantis
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void EnterName(string name)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(name);
        }
        /// <summary>
        /// Кнопка "Добавить проект" в окне "Добавление проекта"
        /// </summary>
        public void AddProject()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void SelectProjectOne()
        {
            driver.FindElement(By.XPath("//tr[1]/td/a")).Click();
        }

        public void DeleteProject()
        {
            driver.FindElement(By.XPath("//input[@class = 'btn btn-primary btn-sm btn-white btn-round']")).Click();
        }

        public void CommitDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@class = 'btn btn-primary btn-white btn-round']")).Click();
        }
        public List<ProjectData> GetProjectList()
        {
            manager.ManagementMenuHelper.Control();
            manager.ManagementMenuHelper.ProjectsTab();
            List<ProjectData> project1 = new List<ProjectData>();

            ICollection<IWebElement> row = driver.FindElements(By.XPath("//tr/td/a"));

            foreach (IWebElement row2 in row)
            {
                string nameProject = row2.Text;

                ProjectData project2 = new ProjectData(nameProject);
                project1.Add(project2);

            }
            return project1;
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
                manager.ManagementMenuHelper.Control();
                manager.ManagementMenuHelper.ProjectsTab();
                //manager.ManagementMenuHelper.InitNewProject();
                // Если проектов нет, создает один
                ProjectData project = new ProjectData();
                project.ProjectName = "Andreevich543";

                Create(project);  // Вызываем метод для создания группы
            }
            return this;
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.ManagementMenuHelper.Control();
            manager.ManagementMenuHelper.ProjectsTab();
            InitNewProjectCreation();
            FillProjectName(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper InitNewProjectCreation()
        {
            manager.ManagementMenuHelper.InitNewProject();
            return this;
        }

        public ProjectManagementHelper FillProjectName(ProjectData project)
        {
            EnterName(project.ProjectName);
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            // Создание группы
            driver.FindElement(By.XPath("//input[@value = 'Добавить проект']")).Click();
            return this;
        }

        public ProjectManagementHelper CreateProject()
        {
            //manager.ManagementMenuHelper.ConProjTab();
            manager.ManagementMenuHelper.InitNewProject();
            string projectName = TestBase.GenerateRandomString(20);
            ProjectData project = new ProjectData(projectName);
            //ProjectData project = new ProjectData(projectName);
            EnterName(project.ProjectName);
            AddProject();
            return this;
        }

        public void ExitMantis()
        {
            driver.FindElement(By.XPath("//div[@id = 'navbar-container']/div[2]/ul/li[3]/a/span")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }
    }
}

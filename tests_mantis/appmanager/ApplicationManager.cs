using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace tests_mantis
{
    public class ApplicationManager
    {
        protected IWebDriver driver; //protected означает что оно внутреннее но наследники получают к нему доступ
        protected string mantis_ver;
        protected string baseURL;
        //protected LoginHelper loginHelper;
        protected ProjectManagementHelper projectMH;
        protected ManagementMenuHelper managmentMH;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            //driver = new ChromeDriver();
            driver = new FirefoxDriver();
            //string geckoDriverPath = @"C:\Windows\SysWOW64\geckodriver.exe";
            //driver = new FirefoxDriver(geckoDriverPath);
            //baseURL = "http://localhost/mantisbt-2.25.4/login_page.php";
            baseURL = "http://localhost/mantisbt-2.25.4";
            //mantis_ver = "2.25.4";
            Registration = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Auth = new LoginHelper(this);
            Admin = new AdminHelper(this, baseURL);
            ApiSoap = new ApiSoapHelper(this);

            projectMH = new ProjectManagementHelper(this);
            managmentMH = new ManagementMenuHelper(this);
        }
        //Деструктор, вызывается автоматически
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            //если менеджер равен нулю
            if (! app.IsValueCreated)
            {
                //нужно создать
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            //если создан то ничего делать не нужно
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }
        public LoginHelper Auth { get; set; }
        public ProjectManagementHelper ProjectManagementHelper { get { return projectMH; } }
        public ManagementMenuHelper ManagementMenuHelper { get { return managmentMH; } }
        public RegistrationHelper Registration { get; set; }
        //public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public ApiSoapHelper ApiSoap { get; set; }

        //public ProjectManagementHelper projectHelper { get; set; }
        //public ManagementMenuHelper menuHelper { get; set; }
    }
}

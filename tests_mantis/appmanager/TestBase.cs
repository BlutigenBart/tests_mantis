using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace tests_mantis
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;

        protected ApplicationManager app;

        [TestFixtureSetUp]
        protected void SetupApplicationManager()
        {
            //Получение доступа к единственному экземпляру который хранится в ApplicationManager
            app = ApplicationManager.GetInstance();

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
        }

        // 1 генератор который генерирует разные числа после вынесения из метода GenerateRandomString
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1; i++) 
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65))); // 223 , 65
            }
            return builder.ToString();
        }

    }
}

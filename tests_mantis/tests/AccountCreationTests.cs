//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using NUnit.Framework;
//using System.IO;

//namespace tests_mantis
//{
//    [TestFixture]
//    public class AccountCreationTests : TestBase
//    {
//        [TestFixtureSetUp]
//        public void setUpConfog()
//        {
//            app.Ftp.BackUpFile("/config_inc.php");
//            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
//            {
//                app.Ftp.Upload("/config_inc.php", localFile);
//            }

//        }

//        /// <summary>
//        /// Измененный по заданию 10.1
//        /// </summary>
//        [Test]
//        public void TestAccountRegistration()
//        {
//            AccountData account = new AccountData()
//            {
//                Name = "testuser99",
//                Password = "password",
//                Email = "testuser99@localhost.localdomain"
//            };

//            List<AccountData> accounts = app.Admin.GetAllAccounts();
//            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

//            if (existingAccount != null) 
//            {
//                app.Admin.DeleteAccount(existingAccount);
//            }
            
//            app.James.Delete(account);
//            app.James.Add(account);

//            app.Registration.Register(account);
//        }

//        /// <summary>
//        /// Тест до задания 10.1
//        /// </summary>
//        //[Test]
//        //public void TestAccountRegistration()
//        //{
//        //    string randomuserdata = GenerateRandomString(9);
//        //    AccountData account = new AccountData()
//        //    {
//        //        Name = randomuserdata,
//        //        Password = "password",
//        //        Email = $"{randomuserdata}@localhost.localdomain"
//        //    };

//        //    app.James.Delete(account);
//        //    app.James.Add(account);

//        //    app.Registration.Register(account);
//        //}

//        [TestFixtureTearDown]
//        public void restoreConfig()
//        {
//            app.Ftp.RestoreBackupFile("/config_inc.php");
//        }
//    }
//}

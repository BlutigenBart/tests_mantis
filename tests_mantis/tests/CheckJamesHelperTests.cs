using NUnit.Framework;
using System;

namespace tests_mantis
{
    [TestFixture]
    public class CheckJamesHelperTests : TestBase
    {
        [Test]
        public void CheckJamesHelperTest()
        {
            AccountData account = new AccountData()
            {
                Name = "xxx",
                Password = "yyy"
            };
            Assert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));
        }
    }
}

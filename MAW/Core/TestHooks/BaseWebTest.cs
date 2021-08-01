using MAW.Core.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAW.Core.TestHooks
{
    class BaseWebTest : BaseTest
    {
      
        [SetUp]
        public void setUp()
        {
            Reporter.CreateTest(TestContext.CurrentContext.Test.Name);
            Browser.LaunchBrowser();
            Browser.GetBrowser().Navigate().GoToUrl("https://cirro-qam1.tsddev.com/account/login");
        }

        [TearDown]
        public void tearDown()
        {
            Reporter.Close();
            Browser.CloseBrowser();
        }
    }
}

using MAW.App.apps;
using MAW.App.Pages;
using MAW.Core.TestHooks;
using MAW.Core.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TSW_Web_UI_Automation.TSDPageObjetPages;

namespace MAW.Tests.web.login

{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class TestLogin : BaseWebTest
    {
       



        [Test, Description("Verify Test description here")]
        public void Login2()
        {
            HomePage homePage = new HomePage();
            homePage.Serach("Selenium");
            System.Threading.Thread.Sleep(5000);

            Reporter.AddScreenshot(Browser.GetScreenshotBase64());

            Reporter.Info("This is a info step");
            Reporter.Pass("Passed");
        }

        [Test, Description("Verify Test description here")]
        public void Login3()
        {
            HomePage homePage = new HomePage();
            homePage.Serach("Awesome");
            System.Threading.Thread.Sleep(5000);

            Reporter.AddScreenshot(Browser.GetScreenshotBase64());

            Reporter.Info("This is a info step");
            Reporter.Pass("Passed");

        }



    }
}

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
    class TestAWeb1 : BaseWebTest
    {
        [Test]
        public void testW1()
        {
            WebReporter.Log.CreateTest("This is  sample");
            TSDHome_Page tSDHome_Page = new TSDHome_Page();
            //CustomLogger.Logger.Info("Navigated To URL");
            tSDHome_Page.TSD_Login();
            tSDHome_Page.TSD_Logout();
            WebReporter.Log.Close();



        }
    }
}

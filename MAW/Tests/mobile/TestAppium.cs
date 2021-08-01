using MAW.App.apps;

using MAW.Core.TestHooks;
using MAW.Core.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TSDHybridFramework.App.MobileScreens;

namespace MAW.Tests.mobile
{
    class TestAppium : BaseMobileTest
    {
        
        [Test]
        public void test()
        {
            MobileReporter.Log.CreateTest("This is  sample");
            HomePage homePage = new HomePage();
            Mobile.LaunchAndroid();
            homePage.login();
            Mobile.Close();
            MobileReporter.Log.Close();



        }

    }
}

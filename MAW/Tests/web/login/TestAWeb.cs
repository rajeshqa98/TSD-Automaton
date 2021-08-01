using MAW.Core.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAW.Tests.web.login
{
    class TestAWeb
    {
        [Test]
        public void testW()
        {
            /* Mobile.LaunchAndroid();

            Mobile.Close();*/
            WebReporter.Log.CreateTest("This is  sample");
            WebReporter.Log.Info("webHello");
            WebReporter.Log.Pass("Hello");
            WebReporter.Log.Close();



        }
    }
}

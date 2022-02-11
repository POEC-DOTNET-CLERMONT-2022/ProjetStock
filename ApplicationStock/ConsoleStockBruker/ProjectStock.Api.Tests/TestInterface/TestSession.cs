using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectStock
{
    public class TestSession
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4727";

        private const string AppPath = @"D:\ProjetStock\ApplicationStock\ApplicationStock\ConsoleStockBruker\WPF_Application\bin\Debug\net6.0-windows\WPF_Application.exe";

        protected static WindowsDriver<WindowsElement> session;

        public static void Setup(TestContext context)
        {
            if(session == null)
            {
                var options = new AppiumOptions();
                options.AddAdditionalCapability("app", AppPath);

                options.AddAdditionalCapability("deviceName","WindowsPC");
                //session = new OpenQA.Selenium.Appium.Windows.WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
                Assert.IsNotNull(session);

               // session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
        }

        public static void TearDown()
        {
            if(session != null)
            {
                //session.Quit();
                session = null;
            }
        }
 
    }

    public class WindowsDriver<T>
    {
    }
}

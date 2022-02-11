using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestProjectStock;

namespace TestProjectStock
{
    [TestClass]
    public class WPFTest :TestSession
    {

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Setup(context);
        }
        [TestMethod]
        public void TestApp()
        {
            //session.FindElementByName("Login").Click();

            session.FindElementById("login_button").Click();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
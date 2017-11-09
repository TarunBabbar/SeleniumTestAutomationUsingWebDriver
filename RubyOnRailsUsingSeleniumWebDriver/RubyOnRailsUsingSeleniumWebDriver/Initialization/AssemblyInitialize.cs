using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Tests.SeleniumWebDriver;

namespace RubyOnRailsUsingSeleniumWebDriver.Initialization
{
    [TestClass]
    public class AssemblySetUp
    {
        public static WebDriver SeleniumDriver = new WebDriver();
        public static string DeploymentDirectory;
        public static TestContext TestContext;

        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            DeploymentDirectory = testContext.DeploymentDirectory;
            TestContext = testContext;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            SeleniumDriver.LaunchBrowser(Browsers.Chrome);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            SeleniumDriver.QuitAndCloseWebDriver();
            SeleniumDriver.Driver = null;
        }
    }
}

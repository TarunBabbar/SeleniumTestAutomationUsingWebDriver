using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstSeleniumWebApplication.SeleniumDriver;

namespace MyFirstSeleniumWebApplication
{
    [TestClass]
    public abstract class AssemblySetUp
    {
        public static string DeploymentDirectory { get; set; }
        public static TestContext TestContext { get; set; }
        protected static WebDriver WebDriver = new WebDriver();

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            DeploymentDirectory = testContext.DeploymentDirectory;
            TestContext = testContext;
        }
    }
}

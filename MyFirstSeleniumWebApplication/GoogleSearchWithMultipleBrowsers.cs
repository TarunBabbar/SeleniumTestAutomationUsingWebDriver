using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstSeleniumWebApplication.SeleniumDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace MyFirstSeleniumWebApplication
{
    [TestClass]
    public class GoogleSearchWithMultipleBrowsers : AssemblySetUp
    {
        [TestMethod]
        public void VerifyGoogleSearch()
        {
            for (int index = 0; index < 3; index++)
            {
                // Create web driver instance for all Browser types:
                WebDriver.LaunchBrowser((Browsers)Enum.Parse(typeof(Browsers), index.ToString()));

                // Launch browser
                WebDriver.Driver.Navigate().GoToUrl("http://www.google.com");

                // Identify Google Search TextBox:
                IWebElement googleSearchTextBox = WebDriver.Driver.FindElement(By.Id("lst-ib"));

                // Type search params in google textbox
                googleSearchTextBox.SendKeys("https://medium.com/");
                IWebElement googleSearchButton = WebDriver.Driver.FindElement(By.Id("_fZl"));
                googleSearchButton.Click();
                WebDriver.Driver.Quit();
                WebDriver.Driver = null;
            }

        }
    }
}

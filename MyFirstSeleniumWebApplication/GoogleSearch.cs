using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace MyFirstSeleniumWebApplication
{
    [TestClass]
    public class GoogleSearch
    {
        [TestMethod]
        public void VerifyGoogleSearch()
        {
            // Create web driver instance for Internet Explorer
            IWebDriver webDriver;
            InternetExplorerOptions opt = new InternetExplorerOptions
            {
                EnableNativeEvents = true,
                IgnoreZoomLevel = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
            };

            webDriver = new InternetExplorerDriver(opt);
            webDriver.Manage().Window.Maximize();

            // Launch IE
            webDriver.Navigate().GoToUrl("http://www.google.com");

            // Identify Google Search TextBox:
            IWebElement googleSearchTextBox = webDriver.FindElement(By.Id("lst-ib"));
            googleSearchTextBox.SendKeys("https://medium.com/");
            IWebElement googleSearchButton = webDriver.FindElement(By.Id("_fZl"));
            googleSearchButton.Click();

            ReadOnlyCollection<IWebElement> paginationLinksOnGoogleSearch = webDriver.FindElements(By.TagName("td"));
        }
    }
}

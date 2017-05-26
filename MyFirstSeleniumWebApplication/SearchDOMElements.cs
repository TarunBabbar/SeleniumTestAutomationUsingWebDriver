﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstSeleniumWebApplication.SeleniumDriver;
using OpenQA.Selenium;

namespace MyFirstSeleniumWebApplication
{
    [TestClass]
    public class SearchDOMElements : AssemblySetUp
    {
        [TestInitialize]
        public void TestInitialize()
        {
            WebDriver.LaunchBrowser(Browsers.Chrome);
        }

        [TestMethod]
        [Description("Identifying DOM element with class name doesn't have space")]
        public void SearchDOMElementWithExactClassName()
        {
            WebDriver.Driver.Navigate().GoToUrl("https://medium.com");

            // Identifying DOM element with class name doesn't have space
            IWebElement mediumLogo = WebDriver.Driver.FindElement(By.ClassName("siteNav-logo"));
            Assert.IsTrue(mediumLogo.Enabled);
        }

        [TestMethod]
        [Description("Identifying DOM element with class name having one space")]
        public void SearchDOMElementContainsClassName()
        {
            WebDriver.Driver.Navigate().GoToUrl("https://medium.com");

            // Class name for 'write a story' link is button button--chromeless u-baseColor--buttonNormal is-inSiteNavBar u-sm-hide u-marginRight15 u-lineHeight30 u-height32 is-touched but we are using sub-part of this classname here:
            IWebElement writeAStoryLink =
                WebDriver.Driver.FindElement(By.XPath("//*[contains(@class, '" + "is-inSiteNavBar u-sm-hide" + "')]")
                );

            writeAStoryLink.Click();
        }
    }
}

using System;
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
            WebDriver.DrawHighlight(mediumLogo);
            Assert.IsTrue(mediumLogo.Enabled);
        }

        [TestMethod]
        [Description("Identifying DOM element with class name having one space")]
        public void SearchDOMElementContainsClassName()
        {
            WebDriver.Driver.Navigate().GoToUrl("https://medium.com");

            // Class name for 'write a story' link is button button--chromeless u-baseColor--buttonNormal is-inSiteNavBar u-sm-hide u-marginRight15 u-lineHeight30 u-height32 is-touched but we are using sub-part of this classname here:
            IWebElement writeAStoryLink =
                WebDriver.Driver.FindElement(By.XPath("//*[contains(@class, '" + "is-inSiteNavBar u-sm-hide" + "')]"));
            WebDriver.DrawHighlight(writeAStoryLink);
            writeAStoryLink.Click();
        }

        [TestMethod]
        [Description("Identifying DOM element with ID not exact Id mentiond on UI Portal")]
        public void SearchDOMElementContainsId()
        {
            WebDriver.Driver.Navigate().GoToUrl("https://medium.com");

            // This will not work, as, Selenium is not able to parse class name with so many spaces
            try
            {
                IWebElement writeAStoryLinkEntireClassName =
                    WebDriver.Driver.FindElement(
                        By.ClassName(
                            "button button--chromeless u-baseColor--buttonNormal is-inSiteNavBar u-sm-hide u-marginRight15 u-lineHeight30 u-height32 is-touched"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Class name for 'write a story' link is button button--chromeless u-baseColor--buttonNormal is-inSiteNavBar u-sm-hide u-marginRight15 u-lineHeight30 u-height32 is-touched but we are using sub-part of this classname here:
            // This will work as selenium is able to parse on space in class name
            IWebElement writeAStoryLink =
                WebDriver.Driver.FindElement(By.XPath("//*[contains(@class, '" + "is-inSiteNavBar u-sm-hide" + "')]")
                );
            WebDriver.DrawHighlight(writeAStoryLink);

            writeAStoryLink.Click();
        }
    }
}

using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RubyOnRailsUsingSeleniumWebDriver.Initialization;

namespace RubyOnRailsUsingSeleniumWebDriver
{
    [TestClass]
    public class CoupaHomePage : AssemblySetUp
    {
        [TestMethod]
        public void CoupaHomePage_SolutionsPage()
        {
            TestContext.WriteLine("Launch Coupa Home Page");
            SeleniumDriver.Navigate("https://www.coupa.com/");

            //Navigate to Solutions Link
            var solutionsLink = SeleniumDriver.Driver.FindElement(By.XPath("//a[contains(@href,'solutions')]"));
            solutionsLink.SendKeys(Keys.Enter);

            string expectedText = "SPEND MANAGEMENT SOLUTIONS THAT WILL CHANGE YOUR BUSINESS";
            var textOnWebElement = SeleniumDriver.Driver.FindElement(By.TagName("h1"));
            Assert.AreEqual(textOnWebElement.Text, expectedText);
            textOnWebElement.Text.Equals(expectedText, StringComparison.OrdinalIgnoreCase).Should().BeTrue();
            textOnWebElement.Text.Should().Be("SPEND MANAGEMENT SOLUTIONS THAT WILL CHANGE YOUR BUSINESS");
        }
    }
}

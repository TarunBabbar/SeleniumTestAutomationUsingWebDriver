using System;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using RubyOnRailsUsingSeleniumWebDriver.Initialization;

namespace Samples.Tests.SeleniumWebDriver
{
    public class WebDriver
    {
        private static IWebDriver webDriver = null;

        public IWebDriver Driver
        {
            get { return webDriver; }
            set { webDriver = value; }
        }

        private static IWebDriver CreateDriver(Browsers browser)
        {
            switch (browser)
            {
                case Browsers.Firefox:
                    Logger.Comment(LogType.Information, "Initializing Firefox browser");
                    if (webDriver == null)
                    {
                        FirefoxDriverService service =
                            FirefoxDriverService.CreateDefaultService(AssemblySetUp.DeploymentDirectory,
                                "geckodriver.exe");
                        webDriver = new FirefoxDriver(service);
                    }
                    break;
                case Browsers.InternetExplorer:
                    if (webDriver == null)
                    {
                        Logger.Comment(LogType.Information, "Initializing Internet Explorer browser");
                        InternetExplorerOptions opt = new InternetExplorerOptions
                        {
                            EnableNativeEvents = true,
                            IgnoreZoomLevel = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        };

                        webDriver = new InternetExplorerDriver(opt);
                    }
                    break;
                case Browsers.Chrome:
                    if (webDriver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("no-sandbox");
                        options.AddArgument("test-type");
                        options.AddArgument("--disable-extensions");
                        webDriver = new ChromeDriver(AssemblySetUp.DeploymentDirectory, options);
                    }
                    break;
                default:
                    Logger.Comment(LogType.Warning,
                        "Could not recognize the browser, Launching Chrome as default browser instead.");
                    goto case Browsers.Chrome;
            }
            return webDriver;
        }

        private void DeleteCookies()
        {
            try
            {
                if (webDriver == null) return;
                webDriver.Manage().Cookies.DeleteAllCookies();
                ProcessStartInfo psInfo =
                    new ProcessStartInfo
                    {
                        FileName = Path.Combine(Environment.SystemDirectory, "RunDll32.exe"),
                        Arguments = "InetCpl.cpl,ClearMyTracksByProcess 2",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true
                    };
                Process p = new Process { StartInfo = psInfo };
                p.Start();
                p.WaitForExit(10000);
            }
            catch (Exception e)
            {
                Logger.Comment(LogType.Error, e.Message);
            }
        }

        public void LaunchBrowser(Browsers browser)
        {
            try
            {
                switch (browser.ToString().ToUpper())
                {
                    case "FIREFOX":
                        webDriver = CreateDriver(Browsers.Firefox);
                        break;
                    case "INTERNETEXPLORER":
                        webDriver = CreateDriver(Browsers.InternetExplorer);
                        break;
                    case "CHROME":
                        webDriver = CreateDriver(Browsers.Chrome);
                        break;
                    default:
                        goto case "FIREFOX";
                }

                DeleteCookies();
                webDriver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Logger.Comment(LogType.Error, ex.Message);
            }
        }

        public void QuitAndCloseWebDriver()
        {
            webDriver.Close();
            webDriver.Quit();
        }

        public void Navigate(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            WaitTillPageIsLoaded();
        }

        public void WaitTillPageIsLoaded()
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(webDriver, TimeSpan.FromSeconds(60.00));
            wait.Until(
                driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}

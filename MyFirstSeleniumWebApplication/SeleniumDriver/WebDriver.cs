using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace MyFirstSeleniumWebApplication.SeleniumDriver
{
    public class WebDriver
    {
        private static IWebDriver webDriver = null;

        public static IWebDriver Driver {get { return webDriver; } set { webDriver = null; } }


        private static IWebDriver CreateDriver(Browsers browser)
        {
            switch (browser)
            {
                case Browsers.Firefox:
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
                        InternetExplorerOptions options = new InternetExplorerOptions
                        {
                            EnableNativeEvents = true,
                            IgnoreZoomLevel = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        };

                        webDriver = new InternetExplorerDriver(options);
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
                ProcessStartInfo psInfo = new ProcessStartInfo();
                psInfo.FileName = Path.Combine(Environment.SystemDirectory, "RunDll32.exe");
                psInfo.Arguments = "InetCpl.cpl,ClearMyTracksByProcess 2";
                psInfo.CreateNoWindow = true;
                psInfo.UseShellExecute = false;
                psInfo.RedirectStandardError = true;
                psInfo.RedirectStandardOutput = true;
                Process p = new Process { StartInfo = psInfo };
                p.Start();
                p.WaitForExit(10000);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
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
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}

using System;
using System.ComponentModel;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AFGmailTestsPOM.Tests
{
    public class TestBase
    {
        //public static IWebDriver driver = new FirefoxDriver();
        //public string Username = "BYTAAFTestUser";
        //public string Userpass = "BYTAAFTestUser1";
        //public string Homepage = "https://gmail.com/";

        public IWebDriver driver;
        [SetUp]
        public void InitBrowser()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities = DesiredCapabilities.InternetExplorer();
            //capabilities.SetCapability(CapabilityType.BrowserName, "internet explorer");
            capabilities = DesiredCapabilities.Firefox();
            capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }

        public string UserName = Properties.Resources.userName;
        public string UserPass = Properties.Resources.userPass;
        public string HomePage = Properties.Resources.homepage;


        static Randomizer rnd = new Randomizer();
        public string Random = rnd.GetString(10);

        public static void WaitForElement(IWebDriver browser,IWebElement element)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10)).Until(e => element.Enabled && element.Displayed);
        }

        public static void WaitForTab(IWebDriver browser, string text)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10)).Until(b => browser.Url.EndsWith(text));
        }
    }
}

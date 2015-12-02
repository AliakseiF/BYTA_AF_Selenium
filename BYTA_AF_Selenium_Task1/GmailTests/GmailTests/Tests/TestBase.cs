using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace GmailTests.Tests
{
    public class TestBase
    {
        public IWebDriver driver = new FirefoxDriver();
        public string username = "BYTAAFTestUser";
        public string userpass = "BYTAAFTestUser1";
        public string homepage = "https://gmail.com/";

        static Randomizer rnd = new Randomizer();
        public string random = rnd.GetString(10);
    }
}

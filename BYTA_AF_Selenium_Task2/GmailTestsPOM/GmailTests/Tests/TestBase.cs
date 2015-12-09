using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace GmailTests.Tests
{
    public class TestBase
    {
        public static IWebDriver driver = new FirefoxDriver();
        public string Username = "BYTAAFTestUser";
        public string Userpass = "BYTAAFTestUser1";
        public string Homepage = "https://gmail.com/";

        static Randomizer rnd = new Randomizer();
        public string Random = rnd.GetString(10);
    }
}

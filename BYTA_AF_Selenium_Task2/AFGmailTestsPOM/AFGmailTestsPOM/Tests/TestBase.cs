using System.ComponentModel;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AFGmailTestsPOM.Tests
{
    public class TestBase
    {
        public static IWebDriver driver = new FirefoxDriver();
        //public string Username = "BYTAAFTestUser";
        //public string Userpass = "BYTAAFTestUser1";
        //public string Homepage = "https://gmail.com/";

        public string UserName = Properties.Resources.userName;
        public string UserPass = Properties.Resources.userPass;
        public string HomePage = Properties.Resources.homepage;


        static Randomizer rnd = new Randomizer();
        public string Random = rnd.GetString(10);
    }
}

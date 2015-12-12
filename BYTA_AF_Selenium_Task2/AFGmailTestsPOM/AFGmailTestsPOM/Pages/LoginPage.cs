using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AFGmailTestsPOM.Pages
{
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(TestBase.driver, this);
        }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement LoginField { get; set; }

        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement PassField { get; set; }

        [FindsBy(How = How.Id, Using = "next")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = "signIn")]
        public IWebElement SingInButton { get; set; }

        [FindsBy(How = How.Id, Using = "back-arrow")]
        public IWebElement BackArrow { get; set; }
    }
}

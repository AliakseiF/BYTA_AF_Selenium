using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Tests;
using OpenQA.Selenium;

namespace AFGmailTestsPOM.Workflows
{
    class LoginPageWf
    {
        LoginPage page;

        public LoginPageWf()
        {
            page = new LoginPage();
        }

        public MailBoxPage LoginToGmail(string login, string pass)
        {
            Console.WriteLine("Log in to gmail...");
            if (page.BackArrow.Displayed)
                page.BackArrow.Click();
            page.LoginField.SendKeys(login);
            page.NextButton.Click();
            page.PassField.SendKeys(pass);
            page.SingInButton.Submit();
            Thread.Sleep(3000);
            return new MailBoxPage();
        }
    }
}

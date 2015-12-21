using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AFGmailTestsPOM.Workflows
{
    public static class LoginPageWf
    {
        public static LoginPage LoginToGmail(this LoginPage page,string login, string pass)
        {
            Console.WriteLine("Log in to gmail...");
            if (page.BackArrow.Displayed)
                page.BackArrow.Click();
            page.LoginField.SendKeys(login);
            page.NextButton.Click();
            page.PassField.SendKeys(pass);
            page.SingInButton.Click();
            //Thread.Sleep(3000);

            //new waiting
            MailBoxPage mailBox = new MailBoxPage(page.PageBrowser);
            TestBase.WaitForElement(page.PageBrowser, mailBox.profile);
            return page;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Tests;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AFGmailTestsPOM.Workflows
{
    class MailBoxPageWf
    {
        MailBoxPage page;

        public MailBoxPageWf()
        {
            page = new MailBoxPage();
        }

        public void CreateNewMail(string to, string subj, string body)
        {
            Console.WriteLine("Creating new mail...");
            page.newMailbnt.Click();
            page.toField.SendKeys(to);
            page.subjField.SendKeys(subj);
            page.bodyField.Click();
            page.bodyField.SendKeys(body);
            Console.WriteLine("Saving new mail...");
            page.saveAndClose.Click();
        }

        public void CheckDraft(string to, string subj, string body)
        {
            Console.WriteLine("Check draft...");
            page.drafts.Click();
            page.requiredMail(subj).Click();
            string to2 = page.receiverToCheck.GetAttribute("email");
            string subj2 = page.subjToCheck.GetAttribute("value");
            string body2 = page.bodyToCheck.Text;
            Assert.AreEqual(to, to2, "to are not equal");
            Assert.AreEqual(subj, subj2, "subj are not equal");
            Assert.AreEqual(body, body2, "subj are not equal");
        }

        public void SendMailAndCheck(string subj)
        {
            Console.WriteLine("Sending mail...");
            page.sendMailbtn.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Checking mail...");
            string a = string.Format("//div[@role='main']//span[contains(., '{0}')]", subj);
            page.sent.Click();
            Thread.Sleep(3000);
            var x = TestBase.driver.FindElements(By.XPath(a)).Count;
            Assert.That(x == 1, "mail was not sent");
            page.drafts.Click();
            Thread.Sleep(3000);
            var y = TestBase.driver.FindElements(By.XPath(a)).Count;
            Assert.That(y == 0, "mail is still in draft");
        }

        public LoginPage LogOut()
        {
            Console.WriteLine("Log out...");
            page.profile.Click();
            page.logOut.Click();
            Assert.That(TestBase.driver.Title == "Gmail");
            return new LoginPage();
        }
    }
}

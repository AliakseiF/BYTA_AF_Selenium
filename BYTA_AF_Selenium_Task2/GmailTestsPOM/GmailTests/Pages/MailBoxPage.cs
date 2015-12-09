using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GmailTests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailTests.Pages
{
    class MailBoxPage
    {
        public MailBoxPage()
        {
            PageFactory.InitElements(TestBase.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        private IWebElement newMailbnt { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']//textarea")]
        private IWebElement toField { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']//input[@name='subjectbox']")]
        private IWebElement subjField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        private IWebElement bodyField { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@data-tooltip='Сохранить и закрыть']")]
        private IWebElement saveAndClose { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/#drafts']")]
        private IWebElement drafts { get; set; }

        private IWebElement requiredMail(string subj)
        {
            string a = string.Format("//span[contains(., '{0}')]", subj);
            IWebElement requiredMail = TestBase.driver.FindElement(By.XPath(a));
            return requiredMail;
        }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']/div[2]//span")]
        private IWebElement receiverToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']/input[@name='subject']")]
        private IWebElement subjToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        private IWebElement bodyToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement sendMailbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/#sent']")]
        private IWebElement sent { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='gb_b gb_Ra gb_R']")]
        private IWebElement profile { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='gb_Ba gb_vd gb_Cd gb_9a']")]
        private IWebElement logOut { get; set; }

        public void CreateNewMail(string to, string subj, string body)
        {
            Console.WriteLine("Creating new mail...");
            newMailbnt.Click();
            toField.SendKeys(to);
            subjField.SendKeys(subj);
            bodyField.Click();
            bodyField.SendKeys(body);
            Console.WriteLine("Saving new mail...");
            saveAndClose.Click();
        }

        public void CheckDraft(string to, string subj, string body)
        {
            Console.WriteLine("Check draft...");
            drafts.Click();
            requiredMail(subj).Click();
            string to2 = receiverToCheck.GetAttribute("email");
            string subj2 = subjToCheck.GetAttribute("value");
            string body2 = bodyToCheck.Text;
            Assert.AreEqual(to, to2, "to are not equal");
            Assert.AreEqual(subj, subj2, "subj are not equal");
            Assert.AreEqual(body, body2, "subj are not equal");
        }

        public void SendMailAndCheck(string subj)
        {
            Console.WriteLine("Sending mail...");
            sendMailbtn.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Checking mail...");
            string a = string.Format("//div[@role='main']//span[contains(., '{0}')]", subj);
            sent.Click();
            Thread.Sleep(3000);
            var x = TestBase.driver.FindElements(By.XPath(a)).Count;
            Assert.That(x == 1, "mail was not sent");
            drafts.Click();
            Thread.Sleep(3000);
            var y = TestBase.driver.FindElements(By.XPath(a)).Count;
            Assert.That(y == 0, "mail is still in draft");
        }

        public LoginPage LogOut()
        {
            Console.WriteLine("Log out...");
            profile.Click();
            logOut.Click();
            Assert.That(TestBase.driver.Title == "Gmail");
            return new LoginPage();
        }
    }
}

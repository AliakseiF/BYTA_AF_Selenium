using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace GmailTests.Tests
{
    public class MainTest : TestBase
    {
        [SetUp]
        public void SayHello()
        {
            Console.WriteLine("Starting gmail test...");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void SayBye()
        {
            Console.WriteLine("Finishing gmail test...");
            driver.Quit();
        }

        [Test]
        public void MainGmailTest()
        {
            LoginToGmail(username, userpass);
            Assert.That(driver.Url.Equals("https://mail.google.com/mail/#inbox"), "Log in failed");
            string to = username+"@gmail.com";
            string subj = "Test subject " + random;
            string body = "Test mail body text: " + random;
            CreateNewMail(to, subj, body);
            CheckDraft(to, subj, body);
            SendMailAndCheck(subj);
            LogOut();
        }

        public IWebElement LoginField
        {
            get { return driver.FindElement(By.Id("Email")); }
        }

        public IWebElement PassField
        {
            get { return driver.FindElement(By.Id("Passwd")); }
        }

        public IWebElement NextButton
        {
            get { return driver.FindElement(By.Id("next")); }
        }

        public IWebElement SingInButton
        {
            get { return driver.FindElement(By.Id("signIn")); }
        }

        public IWebElement BackArrow
        {
            get { return driver.FindElement(By.Id("back-arrow")); }
        }

        private void LoginToGmail(string login, string pass)
        {
            Console.WriteLine("Log in to gmail...");
            driver.Url = homepage;
            if (BackArrow.Displayed)
                BackArrow.Click();
            LoginField.SendKeys(login);
            NextButton.Click();
            PassField.SendKeys(pass);
            SingInButton.Click();
            Thread.Sleep(3000);
        }

        private void CreateNewMail(string to, string subj, string body)
        {
            Console.WriteLine("Creating new mail...");
            driver.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")).Click();
            driver.FindElement(By.XPath("//form[@method='POST']//textarea")).SendKeys(to);
            driver.FindElement(By.XPath("//form[@method='POST']//input[@name='subjectbox']")).SendKeys(subj);
            driver.FindElement(By.XPath("//div[@role='textbox']")).Click();
            driver.FindElement(By.XPath("//div[@role='textbox']")).SendKeys(body);
            driver.FindElement(By.XPath("//img[@data-tooltip='Сохранить и закрыть']")).Click();   
        }

        private void CheckDraft(string to, string subj, string body)
        {
            Console.WriteLine("Check draft...");
            driver.FindElement(By.XPath("//a[@href='https://mail.google.com/mail/#drafts']")).Click();
            string a = string.Format("//span[contains(., '{0}')]", subj);
            driver.FindElement(By.XPath(a)).Click();
            string to2 = driver.FindElement(By.XPath("//form[@method='POST']/div[2]//span")).GetAttribute("email");
            string subj2 = driver.FindElement(By.XPath("//form[@method='POST']/input[@name='subject']")).GetAttribute("value");
            string body2 = driver.FindElement(By.XPath("//div[@role='textbox']")).Text;
            Assert.AreEqual(to, to2, "to are not equal");
            Assert.AreEqual(subj, subj2, "subj are not equal");
            Assert.AreEqual(body, body2, "subj are not equal");
        }

        private void SendMailAndCheck(string subj)
        {
            Console.WriteLine("Sending mail...");
            driver.FindElement(By.XPath("//div[@class='T-I J-J5-Ji aoO T-I-atl L3']")).Click();
            Thread.Sleep(3000);
            string a = string.Format("//div[@role='main']//span[contains(., '{0}')]", subj);
            driver.FindElement(By.XPath("//a[@href='https://mail.google.com/mail/#sent']")).Click();
            Thread.Sleep(3000);
            var x = driver.FindElements(By.XPath(a)).Count;
            Assert.That(x == 1, "mail was not sent");
            driver.FindElement(By.XPath("//a[@href='https://mail.google.com/mail/#drafts']")).Click();
            Thread.Sleep(3000);
            var y = driver.FindElements(By.XPath(a)).Count;
            Assert.That(y == 0, "mail is still in draft");
        }

        private void LogOut()
        {
            Console.WriteLine("Log out...");
            driver.FindElement(By.XPath("//a[@class='gb_b gb_Ra gb_R']")).Click();
            driver.FindElement(By.XPath("//a[@class='gb_Ba gb_vd gb_Cd gb_9a']")).Click();
            Assert.That(driver.Title == "Gmail");
            

        }
    }
}

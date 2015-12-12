using System;
using System.Threading;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace AFGmailTestsPOM.Tests
{
    public class MainTest : TestBase
    {

        [SetUp]
        public void SayHello()
        {
            Console.WriteLine("Starting gmail test...");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(HomePage);
        }

        [TearDown]
        public void SayBye()
        {
            Console.WriteLine("Finishing gmail test...");
            driver.Close();
        }

        [Test]
        public void MainGmailTest()
        {
            LoginPageWf la = new LoginPageWf();
            la.LoginToGmail(UserName, UserPass);
            Assert.That(driver.Url.Equals("https://mail.google.com/mail/#inbox"), "Log in failed");

            MailBoxPageWf ma = new MailBoxPageWf();
            string to = UserName + "@gmail.com";
            string subj = "Test subject " + Random;
            string body = "Test mail body text: " + Random;
            ma.CreateNewMail(to, subj, body);
            ma.CheckDraft(to, subj, body);
            ma.SendMailAndCheck(subj);
            ma.LogOut();

        }
    }
}

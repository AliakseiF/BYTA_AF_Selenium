using System;
using System.Threading;
using GmailTests.Pages;
using GmailTests.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace GmailTests.Tests
{
    public class MainTest:TestBase
    {

        [SetUp]
        public void SayHello()
        {
            Console.WriteLine("Starting gmail test...");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(Homepage);
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
            LoginPage page = new LoginPage();
            MailBoxPage page2 = page.LoginToGmail(Username, Userpass);
            Assert.That(driver.Url.Equals("https://mail.google.com/mail/#inbox"), "Log in failed");

            string to = Username+"@gmail.com";
            string subj = "Test subject " + Random;
            string body = "Test mail body text: " + Random;
            page2.CreateNewMail(to, subj, body);
            page2.CheckDraft(to, subj, body);
            page2.SendMailAndCheck(subj);
            page2.LogOut();

        }
    }
}

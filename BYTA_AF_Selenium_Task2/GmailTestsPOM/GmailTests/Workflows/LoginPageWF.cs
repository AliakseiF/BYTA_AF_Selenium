using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GmailTests.Pages;

namespace GmailTests.Workflows
{
    class LoginPageWf
    {
        public MailBoxPage LoginToGmail(LoginPage page, string login, string pass)
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

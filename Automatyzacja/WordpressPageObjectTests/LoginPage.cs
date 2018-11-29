using System;
using OpenQA.Selenium;
using Xunit;

namespace WordpressPageObjectTests
{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
            _browser.Navigate().GoToUrl(Config.PageUrl);
        }

        internal AdminPage Login(string UserName, string UserPassword)
        {
           
            var UserNameBox = _browser.FindElement(By.Name("log"));
            UserNameBox.SendKeys(UserName);

            var PasswordBox = _browser.FindElement(By.Name("pwd"));
            PasswordBox.SendKeys(UserPassword);
            PasswordBox.Submit();

            return new AdminPage(_browser);
        }

        internal bool IsLoggedOut()
        {
            try
            {
                _browser.FindElement(By.Name("log"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           

        }
    }
}
using System;
using OpenQA.Selenium;

namespace WordpressPageObjectTests
{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal AdminPage Login(string user, string password, string page )
        {
            _browser.Navigate().GoToUrl(page);

            var username = _browser.FindElement(By.Name("log"));
            username.SendKeys(user);

            var pwd = _browser.FindElement(By.Name("pwd"));
            pwd.SendKeys(password);

            var clickToLogin = _browser.FindElement(By.Name("wp-submit"));
            clickToLogin.Click();

            return new AdminPage(_browser);
        }

        internal bool IsLoggeOut()
        {
            throw new NotImplementedException();
        }
    }
}
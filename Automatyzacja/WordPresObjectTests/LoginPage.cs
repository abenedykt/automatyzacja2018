using System;
using OpenQA.Selenium;

namespace WordPresObjectTests
{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal AdminPage Login(string user, string password, string url)
        {

            _browser.Navigate().GoToUrl(url);

            var userName = _browser.FindElement(By.Id("user_login"));
            userName.SendKeys(user);

            var passwordField = _browser.FindElement(By.Id("user_pass"));
            passwordField.SendKeys(password);

            var logIn = _browser.FindElement(By.Id("wp-submit"));
            logIn.Click();
            return new AdminPage(_browser);
        }

        internal bool IsLoggedOut()
        {
            var logged = _browser.FindElement(By.XPath("//*[contains(text(),'Nazwa użytkownika lub e-mail')]"));
            return logged.Text == "Nazwa użytkownika lub e-mail";
        }
    }
}
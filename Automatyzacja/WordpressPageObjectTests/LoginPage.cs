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

        internal AdminPage Login(string url, string user, string password) // metoda Login zwraca stronę administracyjną po zalogowaniu
        {
            _browser.Navigate().GoToUrl(url);

            var inputLogin = _browser.FindElement(By.Id("user_login"));
            var inputPassword = _browser.FindElement(By.Id("user_pass"));
            var submit = _browser.FindElement(By.Id("wp-submit"));

            inputLogin.SendKeys(user);
            inputPassword.SendKeys(password);
            submit.Click();

            return new AdminPage(_browser);
        }

        internal bool IsLoggedOut()
        {
            var logoutMessage = _browser.FindElement(By.ClassName("message")).Text;
            return logoutMessage == "Wylogowano się.";
        }
    }
}
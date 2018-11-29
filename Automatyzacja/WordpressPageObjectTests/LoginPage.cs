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
            _browser.Navigate().GoToUrl(Config.Url);


        }

        internal AdminPage Login(string user, string password)
        {
            
            var loglocator = By.Name("log");
            var login = _browser.FindElement(loglocator);
            login.SendKeys(user);

            var passelement = _browser.FindElement(By.Name("pwd"));
            passelement.SendKeys(password);
            var button = _browser.FindElement(By.Name("wp-submit"));
            button.Click();
            return new AdminPage(_browser);

        }

        internal bool IsLoggedOut()
        {
            if (_browser.FindElements(By.Id("user_pass")).Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }


}
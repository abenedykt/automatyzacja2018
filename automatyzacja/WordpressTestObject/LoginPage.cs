using System;
using OpenQA.Selenium;
using WordpressTestObject;

namespace WordpressPageObjectTests
{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
            _browser.Navigate().GoToUrl(Config.AdminPageUrl);
        }

        internal AdminPage Login(string user, string password)
        {
            //throw new NotImplementedException();
            var logbox = _browser.FindElement(By.Name("log"));
            logbox.SendKeys(Config.User);

            var passbox = _browser.FindElement(By.Name("pwd"));
            passbox.SendKeys(Config.Password);

            passbox.Submit();

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
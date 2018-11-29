using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WordpressPageObjectTests

{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
            _browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");
        }

        internal AdminPage Login(string user, string password)
        {
            var UserName = _browser.FindElement(By.Id("user_login"));
            UserName.SendKeys(user);
            var Password = _browser.FindElement(By.Id("user_pass"));
            Password.SendKeys(password);
            var SignInTab = _browser.FindElement(By.Name("wp-submit"));
            SignInTab.Submit();

            return new AdminPage(_browser);
        }
        internal bool IsLoggedOut()
        {
            //WaitForClickable(By.);
            var message = _browser.FindElement(By.CssSelector(".message")).Text;
            if (message == "Wylogowano się.")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }


}

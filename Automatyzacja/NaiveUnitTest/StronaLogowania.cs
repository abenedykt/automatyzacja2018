using OpenQA.Selenium;

namespace NaiveUnitTest
{
    internal class StronaLogowania
    {
        private IWebDriver _browser;

        public StronaLogowania(IWebDriver browser)
        {
            _browser = browser;
            _browser.Navigate().GoToUrl(Configuration.BlogAdminUrl);
        }

        internal StronaAdministracyjna zaloguj(string userName, string password)
        {
            TypeInUserName(userName);
            TypeInPassword(password);
            ClickLogin();

            return new StronaAdministracyjna(_browser);
        }

        private void ClickLogin()
        {
            _browser.FindElement(By.Id("wp-submit")).Click();
        }

        private void TypeInPassword(string password)
        {
            _browser.FindElement(By.Id("user_pass")).SendKeys(password);
        }

        private void TypeInUserName(string userName)
        {
            var login = By.Id("user_login");
            _browser.FindElement(login).SendKeys(userName);
        }
    }
}
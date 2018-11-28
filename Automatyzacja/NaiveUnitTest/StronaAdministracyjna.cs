using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NaiveUnitTest
{
    internal class StronaAdministracyjna
    {
        private IWebDriver _browser;

        public StronaAdministracyjna(IWebDriver browser)
        {
            _browser = browser;
        }

        internal bool jest_otwarta()
        {
            // todo am I logged in?

            return true;
        }

        internal StronaWylogowania wyloguj()
        {
            IWebElement user_link = _browser.FindElement(By.Id("wp-admin-bar-my-account"));
            HoverMouseOverElement(user_link);

            var logoutButton = By.Id("wp-admin-bar-logout");
            WaitForClickable(logoutButton, 10);
            _browser.FindElement(logoutButton).Click();

            return new StronaWylogowania(_browser);
        }

        private void HoverMouseOverElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
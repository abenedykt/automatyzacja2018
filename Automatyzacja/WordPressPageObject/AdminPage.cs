using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WordPressPageObject
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;

        }

        internal void CreatNewNote()
        {
            var createnote = _browser.FindElement(By.CssSelector("#menu-posts > a > div.wp-menu-name"));
            createnote.Click();

            var newcreatenote = _browser.FindElement(By.CssSelector("#wpbody-content > div.wrap > a"));
            newcreatenote.Click();
        }

        internal void EditNote(Note exampleNote)
        {
            var editTitle = _browser.FindElement(By.CssSelector("#title"));
            editTitle.Click();
            editTitle.SendKeys(Config.Title);

            var editContent = _browser.FindElement(By.CssSelector("#content"));
            editContent.Click();
            editContent.SendKeys(Config.Content);

            var publicButton = _browser.FindElement(By.CssSelector("#publish"));
            publicButton.Click(); 

        }

        private void MoveToElement(By selector)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        internal Uri PublisshNote()
        {
            var url = _browser.FindElement(By.CssSelector("#sample-permalink > a"));
            WaitForClickable(url, 5);
            return new Uri(url.GetAttribute("href"));
        }

        internal LoginPage Logout()
        {
            MoveToElement(By.CssSelector("#wp-admin-bar-my-account > a"));

            var logout = _browser.FindElement(By.CssSelector("#wp-admin-bar-logout"));
            WaitForClickable(logout, 5);
            logout.Click();

            return new LoginPage(_browser);
        }
    }
}
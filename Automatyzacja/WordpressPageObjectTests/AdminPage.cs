using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WordpressPageObjectTests
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal void CreateNewNote()
        {
            var menuItems = _browser.FindElements(By.ClassName("wp-menu-name"));
            menuItems.First(item => item.Text == "Wpisy").Click();

            _browser.FindElement(By.ClassName("page-title-action")).Click();

        }

        internal void EditNote(Note exampleNote)
        {
            var titlebox = _browser.FindElement(By.Id("title"));
            titlebox.Click();
            titlebox.SendKeys(exampleNote.Title);

            _browser.FindElement(By.Id("content-html")).Click();

            var contentbox = _browser.FindElement(By.Id("content"));
            contentbox.Click();
            contentbox.SendKeys(exampleNote.Content);



        }

        internal Uri PublishNote()
        {
            _browser.FindElement(By.Id("publish")).Click();

            WaitForClickable(By.Id("edit-slug-buttons"), 5);
            var url = _browser.FindElement(By.CssSelector("#sample-permalink > a"));

            return new Uri(url.GetAttribute("href"));

        }

        internal LoginPage Logut()
        {


            var userActions = _browser.FindElement(By.Id("wp-admin-bar-my-account"));

            MoveToElement(userActions);



            var logoutlink = _browser.FindElement(By.Id("wp-admin-bar-logout"));

            WaitForClickable(logoutlink, 5);
            logoutlink.Click();

            return new LoginPage(_browser);

        }


        private void MoveToElement(IWebElement element)
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

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
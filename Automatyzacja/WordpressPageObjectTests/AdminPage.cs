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

            var MenuItems = _browser.FindElements(By.ClassName("wp-menu-name"));
            MenuItems.First(Item=>Item.Text=="Wpisy").Click();

            _browser.FindElement(By.LinkText("Dodaj nowy")).Click();

        }

        internal void EditNote(Note exampleNote)
        {
            var AddTitle = _browser.FindElement(By.Id("title"));
            AddTitle.Click();
            AddTitle.SendKeys(exampleNote.Title);

            _browser.FindElement(By.Id("content-html")).Click();

            var AddContent = _browser.FindElement(By.Id("content"));
            AddContent.Click();
            AddContent.SendKeys(exampleNote.Content);



        }

        internal Uri PublishNote()
        {
            WaitForClickable(By.Id("edit-slug-buttons"), 5);
            _browser.FindElement(By.Id("publish")).Click();

            var Permalink = _browser.FindElement(By.CssSelector("#sample-permalink > a"));

            return new Uri(Permalink.GetAttribute("href"));
        }

        internal LoginPage Logout()
        {
            var menu = _browser.FindElement(By.CssSelector("span.display-name"));
            MoveToElement(menu);
            WaitForClickable(By.Id("wp-admin-bar-logout"), 5);

            var Logout = _browser.FindElement(By.Id("wp-admin-bar-logout"));
            Logout.Click();
            return new LoginPage(_browser);


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
    }
}
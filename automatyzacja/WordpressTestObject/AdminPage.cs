using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

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
            //throw new NotImplementedException();

            var menuItems = _browser.FindElements(By.ClassName("wp-menu-name"));
            menuItems.First(item => item.Text == "Wpisy").Click();

            var submenuItems = _browser.FindElements(By.CssSelector(".wp-submenu li a"));
            submenuItems.First(item => item.Text == "Dodaj nowy").Click();

        }

        internal void EditNote(Note exampleNote)
        {
            //throw new NotImplementedException();
            var notTitle = _browser.FindElement(By.Name("post_title"));
            notTitle.Click();
            notTitle.SendKeys(exampleNote.Title);

            _browser.FindElement(By.Id("content-html")).Click();
            var notContent = _browser.FindElement(By.Name("content"));
            notContent.Click();
            notContent.SendKeys(exampleNote.Content);


        }

        internal Uri PublishNote()
        {
            //throw new NotImplementedException();

            WaitForClickable(By.Id("edit-slug-buttons"), 5);
            _browser.FindElement(By.Name("publish")).Click();
            //var Editbtn = _browser.FindElement(By.Id("edit-slug-button"));
                      
            //IWebElement doPublish = _browser.FindElement(By.Name("publish"));
           

            var notUrl = _browser.FindElement(By.CssSelector("#sample-permalink > a"));


            return new Uri(notUrl.GetAttribute("href"));



        }

        internal LoginPage Logout()
        {
            IWebElement logkto = _browser.FindElement(By.ClassName("display-name"));

            Assert.Equal("Jan Automatyczny", logkto.Text);
            MoveToElement(logkto);

            By logoutlinkselector = By.Id("wp-admin-bar-logout");

            WaitForClickable(logoutlinkselector, 5);


            IWebElement log_out = _browser.FindElement(logoutlinkselector);

            log_out.Click();

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
        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}
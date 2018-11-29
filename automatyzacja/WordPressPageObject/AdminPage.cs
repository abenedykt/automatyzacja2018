using OpenQA.Selenium;
using System.Linq;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WordPressPageObject
{
    public class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public void CreateNewNote()
        {
            var posts = _browser.FindElement(By.Id("menu-posts"));

            posts.Click();
            var charts = _browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var addNewPost = charts.Single(x => x.Text == "Dodaj nowy");

            addNewPost.Click();
        }

        public void EditNote(Note exampleNote)
        {
            var title = _browser.FindElement(By.Name("post_title"));
            var content = _browser.FindElement(By.Id("content"));

            title.Click();
            title.SendKeys(exampleNote.Title);
            content.Click();
            content.SendKeys(exampleNote.Content);
        }

        //poczytac o klasie Uri
        public Uri PublishNote()
        {
            WaitForClickable(By.Id("sample-permalink"), 2);
            var urlNote = _browser.FindElement(By.Id("sample-permalink")).GetAttribute("href");
            var publishButton = _browser.FindElement(By.Id("publish"));

            publishButton.Click();

            return new Uri(urlNote);
        }

        public LoginPage LogOut()
        {
            var userName = _browser.FindElements(By.ClassName("display-name")).First();
            MoveToElement(userName);

            var logOutlink = _browser.FindElement(By.Id("wp-admin-bar-logout"));
            WaitForClickable(logOutlink, 1);
            logOutlink.Click();

            return new LoginPage(_browser);
        }

        public bool pageLoaded()
        {
            var kokpit = _browser.FindElement(By.CssSelector(".wrap > h1")).Text.ToLower();
            if (kokpit == "kokpit")
                return true;
            else
                return false;
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
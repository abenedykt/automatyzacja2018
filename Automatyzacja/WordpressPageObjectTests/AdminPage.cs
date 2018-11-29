using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace WordpressPageObjectTests
{
    internal class AdminPage
    {
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
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }



        internal void CreateNewNote()
        {

            var note = _browser.FindElement(By.XPath ("//*[@id='menu-posts']/a/div[3]"));
            note.Click();

            var addnew = _browser.FindElement(By.XPath("//*[@id='wpbody-content']/div[3]/a"));
            addnew.Click();

        }

        internal void EditNote(Note exampleNote)
        {
            var addtitle = _browser.FindElement(By.Name("post_title"));
            addtitle.Click();
            addtitle.SendKeys(exampleNote.Title);

            var addcontent = _browser.FindElement(By.Name("content"));
            addcontent.Click();
            addcontent.SendKeys(exampleNote.Content);   
        }

        internal Uri PublishNote()
        {
            var publish = _browser.FindElement(By.Name("publish"));
            publish.Click();

            WaitForClickable(By.Id("post-status-display"),5);
            var permlink = _browser.FindElement(By.XPath("//*[@id='sample-permalink']/a")).GetAttribute("href");
            return new Uri(permlink);
        }

        internal LoginPage Logout()
        {
            var loginName = _browser.FindElement(By.CssSelector(".display-name"));
            Assert.True(loginName.Text == "Jan Automatyczny");
            MoveToElement(loginName);

            
            var logout = _browser.FindElement(By.Id("wp-admin-bar-logout"));
            logout.Click();

            return new LoginPage(_browser);

           
        }

        private void WaitForClickable(By by, int seconds)

        {

            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

        }
    }
}
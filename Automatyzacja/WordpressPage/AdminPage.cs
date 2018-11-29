using System;
using OpenQA.Selenium;
using WordpressPage;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Linq;
using OpenQA.Selenium.Interactions;

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
            var MenuItems = _browser.FindElements(By.CssSelector(".wp-menu-name"));
            MenuItems.Single(x=>x.Text== "Wpisy").Click();
            var AddNewEntry = _browser.FindElement(By.CssSelector("#menu-posts > ul > li:nth-child(3) > a"));
            AddNewEntry.Click();

        }
        
        internal void EditNote(Note exampleNote)
        {
            var EntryTheTitle = _browser.FindElement(By.Name("post_title"));
            EntryTheTitle.SendKeys(exampleNote.Title);
            var AddComment = _browser.FindElement(By.Name("content"));
            AddComment.SendKeys(exampleNote.Content); 
        }
        
        internal object Logout()
        {
            var Photo = _browser.FindElement(By.CssSelector("#wp-admin-bar-my-account > a > img"));
            MoveToElement(Photo);
            _browser.Manage()
               .Timeouts()
               .ImplicitWait = TimeSpan.FromSeconds(5);

            var logOut = _browser.FindElement(By.CssSelector("#wp-admin-bar-logout > a"));
            logOut.Click();

            return new AdminPage(_browser);
        }

        internal Uri PublishNote()
        {
            var PublishTab = _browser.FindElement(By.Name("publish"));
            PublishTab.Click();
            var newLink = _browser.FindElement(By.XPath("//*[@id='sample-permalink']/a"));
            return new Uri (newLink.GetAttribute("href"));
            
        }
        private void MoveToElement(IWebElement photo)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(photo);
            moveTo.Build().Perform();

        }
    }
}
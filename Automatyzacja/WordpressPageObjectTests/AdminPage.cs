using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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

            var note = _browser.FindElement(By.XPath ("//*[@id='menu-posts']/a/div[3]"));
            note.Click();

            var addnew = _browser.FindElement(By.XPath("//*[@id='wpbody-content']/div[3]/a"));
            addnew.Click();

        }

        internal void EditNote(Note exampleNote)
        {
            var addnewnote = _browser.FindElement(By.Name("post_title"));
            addnewnote.Click();
                        
        }

        internal Uri PublishNote()
        {
            throw new NotImplementedException();
        }

        internal LoginPage Logout()
        {
            throw new NotImplementedException();
        }
    }
}
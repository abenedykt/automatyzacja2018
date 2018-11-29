using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WordpressPageObjectTests
{
    internal class NotePage
    {
        private IWebDriver _browser;
        private Uri newNoteUrl;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            _browser = browser;
            this.newNoteUrl = newNoteUrl;
            _browser.Navigate().GoToUrl(newNoteUrl);
            
        }

        internal string Title()
        {
            var title = _browser.FindElement(By.CssSelector("h1"));
            return title.Text;
        }

        internal string Content()
        {
            var content = _browser.FindElement(By.XPath("//*[@class='entry-content']/p"));
            return content.Text;
        }
    }
}
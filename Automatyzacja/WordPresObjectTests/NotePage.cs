using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WordPresObjectTests
{
    internal class NotePage
    {
        private Uri newNoteUrl;
        private IWebDriver _browser;
        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            _browser = browser;
            this.newNoteUrl = newNoteUrl;

            browser.Navigate().GoToUrl(newNoteUrl);
        }
        internal string Title()
        {
            var title = _browser.FindElement(By.XPath("//*[@class='entry-title']")).Text;
            return title;
        }
        internal string Content()
        {
            var content = _browser.FindElement(By.XPath("//*[@class='entry-content']/p")).Text;
            return content;
        }
    }
}
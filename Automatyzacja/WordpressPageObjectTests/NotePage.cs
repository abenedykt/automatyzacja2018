using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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

        public string Title => _browser.FindElement(By.ClassName("entry-title")).Text;

        public string Content => _browser.FindElement(By.ClassName("entry-content")).Text;
    }
}
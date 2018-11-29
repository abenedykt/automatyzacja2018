using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WordpressPageObjectTests
{
    internal class NotePage
    {
        private IWebDriver _browser;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            _browser = browser;
            _browser.Navigate().GoToUrl(newNoteUrl);
        }

        public string Title
        {
            get
            {
                return _browser.FindElement(By.CssSelector(".entry-title")).Text;
            }
        }

        public string Content
        {
            get
            {
                return _browser.FindElement(By.CssSelector(".entry-content")).Text;
            }
        }
    }
}
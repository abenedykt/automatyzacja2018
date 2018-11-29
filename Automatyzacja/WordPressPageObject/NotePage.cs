using System;
using OpenQA.Selenium;

namespace WordPressPageObject
{
    internal class NotePage
    {
        private IWebDriver _browser;
        private Uri newNoteUrl;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            _browser = browser;
            this.newNoteUrl = newNoteUrl;
        }
    }
}
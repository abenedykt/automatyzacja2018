using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WordpressPageObjectTests
{
    internal class NotePage
    {
        private Uri neNoteUrl;

        public NotePage(IWebDriver _browser, Uri neNoteUrl)
        {
            this.neNoteUrl = neNoteUrl;
            _browser.Navigate().GoToUrl(neNoteUrl.OriginalString);

            this.Title = _browser.FindElement(By.ClassName("entry-title")).Text;
            this.Content = _browser.FindElement(By.ClassName("entry-content")).Text;
        }

        public string Title { get; internal set; }
        public string Content { get; internal set; }
    }
}
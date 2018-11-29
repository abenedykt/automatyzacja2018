using System;
using System.Collections.Generic;
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
            this .newNoteUrl = newNoteUrl;

            _browser.Navigate().GoToUrl(newNoteUrl.OriginalString);

            Title = _browser.FindElement(By.ClassName("entry-title")).Text;

            Content = _browser.FindElement(By.ClassName("entry-content")).Text;


        }

        public string Content { get; internal set; }
        public string Title { get; internal set; }
    }
}
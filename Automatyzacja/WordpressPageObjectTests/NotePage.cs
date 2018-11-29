using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WordpressPageObjectTests
{
    internal class NotePage
    {
        private Uri newNoteUrl;

        public NotePage(IWebDriver _browser, Uri newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }

        public string Title { get; internal set; }
        public string Content { get; internal set; }
    }
}
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
        }

        public string Title { get; internal set; }
        public string Content { get; internal set; }
    }
}
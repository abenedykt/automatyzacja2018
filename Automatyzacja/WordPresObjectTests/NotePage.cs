using System;
using OpenQA.Selenium;

namespace WordPresObjectTests
{
    internal class NotePage
    {
        private Uri newNoteUrl;

        public NotePage(IWebDriver browser, Uri newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }

        public string Content { get; internal set; }
        public string Title { get; internal set; }
    }
}
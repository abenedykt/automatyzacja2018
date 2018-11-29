using System;

namespace WordpressPageObjectTests
{
    internal class NotePage
    {
        private Uri newNoteUrl;

        public NotePage(Uri newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }
    }
}
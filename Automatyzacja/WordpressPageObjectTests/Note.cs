namespace WordpressPageObjectTests
{
    internal class Note
    {
        private string title;
        private string content;

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
    }
}
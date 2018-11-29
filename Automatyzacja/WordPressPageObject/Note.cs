namespace WordPressPageObject
{
    internal class Note
    {
        private string v1;
        private string v2;

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get => v1; set => v1 = value; }
        public string Content { get => v2; set => v2 = value; }
    }
}
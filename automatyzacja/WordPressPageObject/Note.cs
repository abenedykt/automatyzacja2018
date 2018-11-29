namespace WordPressPageObject
{
    public class Note
    {
        private string v1;
        private string v2;

        public Note(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public string Title { get => v1; set => v1 = value; }
        public string Content { get => v2; set => v2 = value; }
    }
}
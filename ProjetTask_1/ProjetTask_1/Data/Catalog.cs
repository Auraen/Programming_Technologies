namespace ProjetTask_1.DataLayer
{
    internal class Catalog
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public Catalog(string title, string author)
        {
            Author = author;
            Title = title;
        }

    }
}

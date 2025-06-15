namespace BiblioInheritance
{
    public class Book : Resource
    {
        public List<string> Authors { get; private set; }
        public int PageCount { get; private set; }

        public Book(string title, string author, int pageCount, string category) : base(title, category)
        {
            Authors = new List<string> { author };
            PageCount = pageCount;
        }

        public void AddAuthor(string author)
        {
            if (!Authors.Contains(author))
                Authors.Add(author);
        }

        public override void GetInfo()
        {
            base.GetInfo();

            var authorsList = Authors.Count > 0 ? string.Join(", ", Authors) : "No authors listed";
            Console.WriteLine($"Authors: {authorsList}");
            Console.WriteLine($"Page Count: {PageCount}");
        }
    }
}
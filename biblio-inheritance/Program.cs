namespace BiblioInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 180, "Fiction");
            var periodical = new Periodical("National Geographic", "Monthly", "Science");
            var video = new Video("Inception", "Sci-Fi", "Christopher Nolan", 148, "DVD");

            book.GetInfo();
            Console.WriteLine("\n");
            periodical.GetInfo();
            Console.WriteLine("\n");

            video.Checkout("Alice");
            video.Checkout("Bob");
            video.GetInfo();

            Console.WriteLine("\n");
            video.Return();
            video.GetInfo();
        }
    }
}
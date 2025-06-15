namespace BiblioInheritance
{
    public class Video : Resource
    {
        public string Director { get; private set; }
        public int Runtime { get; private set; }
        public string MediaType { get; private set; }

        public Video(string title, string category, string director, int runtime, string mediaType) : base(title, category)
        {
            Director = director;
            Runtime = runtime;
            MediaType = mediaType;
        }

        public override void GetInfo()
        {
            base.GetInfo();

            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Runtime: {Runtime} minutes");
            Console.WriteLine($"Media Type: {MediaType}");
        }
    }
}
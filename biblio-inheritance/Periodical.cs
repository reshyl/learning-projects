namespace BiblioInheritance
{
    public class Periodical : Resource
    {
        public string Period { get; private set; }

        public Periodical(string title, string period, string category) : base(title, category)
        {
            Period = period;
        }

        public override void UpdateStatus()
        {
            if (Status == "Available")
                Status = "In-use";
            else if (Status == "In-use")
                Status = "Available";
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Period: {Period}");
        }
    }
}
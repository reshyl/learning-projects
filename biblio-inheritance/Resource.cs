namespace BiblioInheritance
{
    public class Resource
    {
        public string Title { get; protected set; }
        public string Category { get; protected set; }
        public string Status { get; protected set; }
        public Queue<string> Holds { get; protected set; }

        public Resource(string title, string category)
        {
            Title = title;
            Category = category;
            Status = "Available";
            Holds = new Queue<string>();
        }

        public virtual void UpdateStatus()
        {
            if (Status == "Available")
                Status = "Out";
            else if (Status == "Out")
                Status = "Available";
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Status: {Status}");

            if (Holds.Count > 0)
                Console.WriteLine($"Holds: {string.Join(", ", Holds)}");
        }

        public virtual void Checkout(string patron)
        {
            if (Status == "Available")
            {
                UpdateStatus();
                Console.WriteLine($"{Title} has been checked out by {patron}.");
            }
            else
            {
                Holds.Enqueue(patron);
                Console.WriteLine($"{Title} is currently checked out. {patron} has been added to the hold list.");
            }
        }

        public virtual void Return()
        {
            if (Status == "Available")
            {
                Console.WriteLine($"{Title} is not currently checked out.");
            }
            else
            {
                UpdateStatus();
                Console.WriteLine($"{Title} has been returned.");

                if (Holds.Count > 0)
                {
                    var nextPatron = Holds.Dequeue();
                    Console.WriteLine($"{nextPatron} can now check out {Title}.");
                    Checkout(nextPatron);
                }
            }
        }
    }
}
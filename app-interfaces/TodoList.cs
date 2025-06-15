namespace AppInterfaces
{
    class TodoList : IDisplayable, IResetable
    {
        public string[] Todos { get; private set; }
        public char HeaderSymbol => '-';

        private int nextOpenIndex;

        public TodoList()
        {
            Todos = new string[5];
            nextOpenIndex = 0;
        }

        public void Add(string todo)
        {
            if (nextOpenIndex >= Todos.Length)
            {
                Console.WriteLine("Todo list is full. Cannot add more items.");
                return;
            }

            Todos[nextOpenIndex] = todo;
            nextOpenIndex++;
        }

        public void Display()
        {
            Console.WriteLine("Todos");
            Console.WriteLine(new string(HeaderSymbol, 10));

            for (int i = 0; i < Todos.Length; i++)
            {
                if (string.IsNullOrEmpty(Todos[i]))
                    Console.WriteLine("[]");
                else
                    Console.WriteLine(Todos[i]);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < Todos.Length; i++)
                Todos[i] = string.Empty;

            nextOpenIndex = 0;
        }
    }
}


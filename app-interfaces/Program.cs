namespace AppInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var tdl = new TodoList();
            tdl.Add("Invite friends");
            tdl.Add("Buy decorations");
            tdl.Add("Party");
            tdl.Display();

            var pm = new PasswordManager("iluvpie123", true);
            pm.Display();
        }
    }
}


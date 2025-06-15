namespace AppInterfaces
{
    class PasswordManager : IDisplayable, IResetable
    {
        public char HeaderSymbol => '-';
        public bool Hidden { get; private set; }
        private string Password { get; set; } = string.Empty;

        public PasswordManager(string password, bool hidden)
        {
            if (SetPassword(password))
                Hidden = hidden;
        }

        public void Display()
        {
            Console.WriteLine("Password");
            Console.WriteLine(new string(HeaderSymbol, 10));

            if (Hidden)
            {
                var passwordDisplay = new string('*', Password.Length);
                Console.WriteLine(passwordDisplay);
            }
            else
            {
                Console.WriteLine(Password);
            }
        }

        public void Reset()
        {
            Password = string.Empty;
            Hidden = false;
        }

        public bool SetPassword(string newPassword)
        {
            if (newPassword.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long.");
                return false;
            }

            Password = newPassword;
            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (Password == oldPassword)
            {
                if (SetPassword(newPassword))
                {
                    Console.WriteLine("Password changed successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to change password.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Old password is incorrect. Password not changed.");
                return false;
            }
        }
    }
}



using System.Text;

namespace passwordManager
{
    internal class Program

    {   // password manager

        /*list all password 
         * change or add password
         * get password
         * delet password
         */
        private static readonly Dictionary<string, string> _PasswordEntries = new();
        static void Main(string[] args)

        {

            _PasswordEntries.Add("MasterKey", "sherif123");
            Console.Write("Enter the MasterKey password : ");
            string masterKeyPassword = Console.ReadLine();
            if (_PasswordEntries["MasterKey"] != masterKeyPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password ");
            }
            else


            {
                while (true)
                {
                    ReadPasswords();
                    Console.WriteLine("select an option please: ");
                    Console.WriteLine("1.list all password ");
                    Console.WriteLine("2.chane or add password");
                    Console.WriteLine("3.get password");
                    Console.WriteLine("4.delet password");
                    Console.WriteLine("5.for exit");
                    var SelectOption = Console.ReadLine();


                    if (SelectOption == "1")
                        ListAllPassword();
                    else if (SelectOption == "2")
                        ChangeOrAddPassword();

                    else if (SelectOption == "3")
                        GetPassword();
                    else if (SelectOption == "4")
                        DeletPassword();
                    else if (SelectOption == "5")
                        exit();
                    else
                        Console.WriteLine("Invalid input ");
                    Console.WriteLine("___________________________________");

                }

            }
        }

        private static void exit()
        {
            Environment.Exit(0);
        }

        private static void ReadPasswords()
        {
            if (File.Exists("password.txt"))
            {
                _PasswordEntries.Clear();
                var passwordlines = File.ReadAllText("password.txt");
                foreach (var line in passwordlines.Split(Environment.NewLine))
                    if (!string.IsNullOrEmpty(line))
                    {
                        var equalindex = line.IndexOf('=');
                        var appname = line.Substring(0, equalindex).Trim();
                        var password = line.Substring(equalindex + 1).Trim();// بعد اليساوي
                       _PasswordEntries.Add(appname,Encruption.Decrypt( password));
                    }


            }

        }
        private static void SavePassword()
        {
            var sb = new StringBuilder();
            foreach (var entry in _PasswordEntries)
                sb.AppendLine($"{entry.Key} = {Encruption.Encrypt(entry.Value)}");
            File.WriteAllText("password.txt", sb.ToString());


        }

        private static void DeletPassword()
        {

            Console.Write("please enter website app : ");
            var appName = Console.ReadLine();
            if (_PasswordEntries.ContainsKey(appName))
            {

                _PasswordEntries.Remove(appName);
            }
            else
                Console.WriteLine("password not found ");
        }

        private static void GetPassword()
        {
            Console.Write("your app you want to get password is : ");
            var webname = Console.ReadLine();
            if (_PasswordEntries.ContainsKey(webname))
                Console.WriteLine($"the password of {webname} is {_PasswordEntries[webname]}");
            else
                Console.WriteLine("the web does not exist ");

        }

        private static void ChangeOrAddPassword()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.Write("Enter your website/app name :");
                var appname = Console.ReadLine();
                Console.Write($" the password of {appname} is : ");
                var password = Console.ReadLine();

                {

                    if (password == null || string.IsNullOrWhiteSpace(appname))
                        Console.WriteLine("invalid password");
                    else
                    {

                        if (_PasswordEntries.ContainsKey(appname))
                            _PasswordEntries[appname] = password;
                        else
                        { _PasswordEntries.Add(appname,Encruption.Encrypt( password)); }
                        SavePassword();
                    }
                }
                Console.Write("Do you want to add more or exist choice y/n : ");
                var choice = Console.ReadLine();
                if (choice == null)
                {
                    Console.WriteLine("invalid choice");
                }
                else
                {
                    if (choice == "y")
                        keeprunning = true;
                    else
                        keeprunning = false;


                }


            }





        }

        private static void ListAllPassword()
        {
            //Console.WriteLine(string.Join(" , ", _PasswordEntries));
            foreach (var entry in _PasswordEntries)
                Console.WriteLine($"{entry.Key} = {entry.Value}");
        }
    }
}

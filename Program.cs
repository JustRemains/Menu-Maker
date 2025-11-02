namespace Menu_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string menuFile = Path.Combine(menuFilePath, "Menu.txt");


            List<string> menu = new()
            {
                "Chicken Alfredo",
                "Steak, Potatoes, and Veggies",
                "Spaghetti and Meatballs",
                "Tacos",
                "Seafood Boil",
                "Burgers, Beans, French Fries",
                "Hot Dogs, Mac and Cheese, French Fries",
            };

           
            DisplayBanner();
            while (true)
            {
             ConsoleKeyInfo KeyInfo = Console.ReadKey();
                if(KeyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            for(int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }

        }
        public static void AddMenuItem(List<string> Menu)
        {
            Menu.Add(Console.ReadLine());
            
        }

        public static void RemoveMenuItem(List<string> Menu)
        {
            Menu.Remove(Console.ReadLine());
        }

        public static void DisplayBanner()
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(" __  __ _____ _   _ _   _     __  __    _    _  _  __ _____ ____  ");
            Console.WriteLine("|  \\/  | ____| \\ | | | | |   |  \\/  |  / \\  | | |/ /| ____|  _ \\ ");
            Console.WriteLine("| |\\/| |  _| |  \\| | | | |   | |\\/| | / _ \\ | | ' / |  _| | |_) |");
            Console.WriteLine("| |  | | |___| |\\  | |_| |   | |  | |/ ___ \\| | . \\ | |___|  _ < ");
            Console.WriteLine("|_|  |_|_____|_| \\_|\\___/    |_|  |_/_/   \\_\\_|_|\\_\\|_____|_| \\_\\");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Click enter to create a random menu (Hit ESC key to exit)");
        }


    }
}

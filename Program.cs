using System.Globalization;

namespace Menu_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //******ALL WORK IN PROGRESS******

            // Define file path for menu storage
            string menuFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string menuFile = Path.Combine(menuFilePath, "Menu.txt");

            List<string> menu = new()
            {

            };

            ReadMenuFile(menuFile, menu);
            Red(); DisplayBanner(); Normal();
            while (true)
            {
                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                if (KeyInfo.Key == ConsoleKey.Tab)
                {
                    Red();
                    DisplayMenuBanner();
                    Green();
                    Console.Write(GenerateRandomMenu(menu));
                    Normal();
                }
                if (KeyInfo.Key == ConsoleKey.Escape)
                {
                    Red();
                    DisplayFooter();
                    Normal();
                    break;
                }

                CommandLineSystem(menu, menuFile);

            }


        }

        //Command line system for adding and deleting menu items
        private static void CommandLineSystem(List<string> menu, string menuFile)
        {
            string command = Console.ReadLine();

            if (command.StartsWith('/'))
            {

                switch (command.ToLower())
                {
                    case "/add":
                        Console.Write("Enter the food item to add: ");
                        AddMenuItem(menu, menuFile, Console.ReadLine() ?? "");
                        break;

                    case "/delete":
                        Console.Write("Enter the food item to delete: ");
                        DeleteMenuItem(menu, menuFile, Console.ReadLine() ?? "");
                        break;

                    default:
                        Console.WriteLine("Unknown command. Please use /add or /delete.");
                        break;
                }
            }
        }

        //Add menu item
        private static void AddMenuItem(List<string> menu, string menuFile, string newItem)
        {
            if (!menu.Contains(newItem))
            {

                using StreamWriter writer = new StreamWriter(menuFile, true);
                menu.Add(newItem);
                writer.WriteLine(newItem);
                writer.Close();
                Console.WriteLine($"Added {newItem} to the menu.");
            }
            else
            {
                Console.WriteLine("Item already exists in the menu.");
            }
        }

        //delete menu item
        private static void DeleteMenuItem(List<string> menu, string menuFile, string deleteItem)
        {
            if (menu.Contains(deleteItem))
            {
                menu.Remove(deleteItem);
                File.WriteAllLines(menuFile, menu);
                Console.WriteLine($"Deleted {deleteItem} from the menu.");
            }
            else
            {
                Console.WriteLine("Item not found in the menu.");
            }
        }

        //Reads file menu
        private static void ReadMenuFile(string menuFile, List<string> menu)
        {
            if (!File.Exists(menuFile))
            {
                File.Create(menuFile).Close();
            }
            using StreamReader reader = new StreamReader(menuFile);
            foreach (string line in File.ReadLines(menuFile))
            {
                menu.Add(line);
            }
            reader.Close();
        }

        //Generate a random menu for the week
        private static string GenerateRandomMenu(List<string> menu)
        {

            Random rand = new Random();
            string[] daysOfWeek = new[]
            {
                "Monday:",
                "Tuesday:",
                "Wednesday:",
                "Thursday:",
                "Friday:",
                "Saturday:",
                "Sunday:"
            };

            if (menu == null || menu.Count <= 0)
            {
                return "Menu is empty. Please add items to the menu.";
            }
            else
            {
                foreach (string day in daysOfWeek)
                {
                    int randomIndex = rand.Next(menu.Count);
                    Console.WriteLine($"{day} {menu[randomIndex]}");
                }
            }
            return "";
        }

        //Display banner and instructions
        private static void DisplayBanner()
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(" __  __ _____ _   _ _   _     __  __    _     __  __ _____ ____  ");
            Console.WriteLine("|  \\/  | ____| \\ | | | | |   |  \\/  |  / \\    | |/ /| ____|  _ \\ ");
            Console.WriteLine("| |\\/| |  _| |  \\| | | | |   | |\\/| | / _ \\   | ' / |  _| | |_) |");
            Console.WriteLine("| |  | | |___| |\\  | |_| |   | |  | |/ ___ \\  |   \\ | |___|  _ < ");
            Console.WriteLine("|_|  |_|_____|_| \\_|\\___/    |_|  |_/_/   \\_\\_|_|\\_\\|_____|_| \\_\\");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Click Tab key to create a random menu (Hit ESC key to exit)\n");
            Console.WriteLine("Your menu is empty. type /add + enter to add food items and /delete + enter to remove.\n");

        }

        //Display menu banner
        private static void DisplayMenuBanner()
        {
            Console.WriteLine("================================");
            Console.WriteLine(" __  __ _____ _   _ _   _ ");
            Console.WriteLine("|  \\/  | ____| \\ | | | | |");
            Console.WriteLine("| |\\/| |  _| |  \\| | | | |");
            Console.WriteLine("| |  | | |___| |\\  | |_| |");
            Console.WriteLine("|_|  |_|_____|_| \\_|\\___/ ");
            Console.WriteLine("================================");
        }

        //Display footer
        private static void DisplayFooter()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      Thank you for using       ");
            Console.WriteLine("          Menu Maker!           ");
            Console.WriteLine("================================");
        }

        //Console color methods
        private static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private static void Normal()
        {
            Console.ResetColor();
        }
        private static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}

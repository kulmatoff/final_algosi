using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final_ALgosi
{
    internal class StudentsApp
    {
        public HashTable students = new HashTable(10);

        public void StartApp()
        {
            while (true)
            {
                this.Input();
            }
        }
        public void Input()
        {
            Menu("list");

            Console.WriteLine("\nType command (add/rem/edit/about/ex)");
            string prompt = Console.ReadLine();
            string[] sp = prompt.Split(' ');

            switch (sp[0].ToLower())
            {
                case "add":
                    {
                        if (sp.Length != 3)
                        {
                            Console.WriteLine("Not enough arguments. (Add Name Phone)");
                            break;
                        }
                        students[sp[1]] = sp[2];
                        Menu("list");
                        break;
                    }
                case "edit":
                    {
                        Menu("edit");
                        break;
                    }
                case "about":
                    {
                        Menu("about");
                        break;
                    }
                case "rem":
                    {
                        if (sp.Length > 1)
                        {
                            students.Remove(sp[1]);
                            Menu("list");
                            break;
                        }
                        Menu("remove");
                        break;
                    }
                case "ex":
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong command");
                        break;
                    }
            }
        }


        public void Menu(string menu)
        {
            Console.Clear();
            Console.WriteLine("  ██████ ▄▄▄█████▓ █    ██ ▓█████▄ ▓█████  ███▄    █ ▄▄▄█████▓  ██████     ▄▄▄       ██▓███   ██▓███  \r\n▒██    ▒ ▓  ██▒ ▓▒ ██  ▓██▒▒██▀ ██▌▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒▒██    ▒    ▒████▄    ▓██░  ██▒▓██░  ██▒\r\n░ ▓██▄   ▒ ▓██░ ▒░▓██  ▒██░░██   █▌▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░░ ▓██▄      ▒██  ▀█▄  ▓██░ ██▓▒▓██░ ██▓▒\r\n  ▒   ██▒░ ▓██▓ ░ ▓▓█  ░██░░▓█▄   ▌▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░   ▒   ██▒   ░██▄▄▄▄██ ▒██▄█▓▒ ▒▒██▄█▓▒ ▒\r\n▒██████▒▒  ▒██▒ ░ ▒▒█████▓ ░▒████▓ ░▒████▒▒██░   ▓██░  ▒██▒ ░ ▒██████▒▒    ▓█   ▓██▒▒██▒ ░  ░▒██▒ ░  ░\r\n▒ ▒▓▒ ▒ ░  ▒ ░░   ░▒▓▒ ▒ ▒  ▒▒▓  ▒ ░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ▒ ▒▓▒ ▒ ░    ▒▒   ▓▒█░▒▓▒░ ░  ░▒▓▒░ ░  ░\r\n░ ░▒  ░ ░    ░    ░░▒░ ░ ░  ░ ▒  ▒  ░ ░  ░░ ░░   ░ ▒░    ░    ░ ░▒  ░ ░     ▒   ▒▒ ░░▒ ░     ░▒ ░     \r\n░  ░  ░    ░       ░░░ ░ ░  ░ ░  ░    ░      ░   ░ ░   ░      ░  ░  ░       ░   ▒   ░░       ░░       \r\n      ░              ░        ░       ░  ░         ░                ░           ░  ░                  \r\n                            ░                                                                         ");
            Console.WriteLine("Project by Baiastan Kulmatov SEST-3-22\n\n");
            List<Item> items = students.GetElements();

            if (menu.ToLower() == "list")
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.Write(items[i].key + " " + items[i].value + ", \t ");
                    if ((i + 1) % 4 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

            if (menu.ToLower() == "remove")
            {
                int selectedElement = 0;
                bool removing = true;
                while (removing)
                {
                    Console.Clear();
                    Console.WriteLine("What element to remove?");
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == selectedElement)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(items[i].key + " " + items[i].value);
                        Console.ResetColor();
                    }
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            {
                                students.Remove(items[selectedElement].key);
                                Console.WriteLine(items[selectedElement].key);
                                removing = false;
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                selectedElement--;
                                if (selectedElement < 0)
                                {
                                    selectedElement = items.Count - 1;
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                selectedElement = (selectedElement + 1) % items.Count;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                Menu("list");
            }

            else if (menu.ToLower() == "about")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("A project for");
                Console.WriteLine("  ██████  ▒█████   ██▓    ▄▄▄█████▓ ▒█████   ███▄    █  ▒█████  ▓█████  ██▒   █▓\r\n▒██    ▒ ▒██▒  ██▒▓██▒    ▓  ██▒ ▓▒▒██▒  ██▒ ██ ▀█   █ ▒██▒  ██▒▓█   ▀ ▓██░   █▒\r\n░ ▓██▄   ▒██░  ██▒▒██░    ▒ ▓██░ ▒░▒██░  ██▒▓██  ▀█ ██▒▒██░  ██▒▒███    ▓██  █▒░\r\n  ▒   ██▒▒██   ██░▒██░    ░ ▓██▓ ░ ▒██   ██░▓██▒  ▐▌██▒▒██   ██░▒▓█  ▄   ▒██ █░░\r\n▒██████▒▒░ ████▓▒░░██████▒  ▒██▒ ░ ░ ████▓▒░▒██░   ▓██░░ ████▓▒░░▒████▒   ▒▀█░  \r\n▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░ ▒░▓  ░  ▒ ░░   ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░ ▒░▒░▒░ ░░ ▒░ ░   ░ ▐░  \r\n░ ░▒  ░ ░  ░ ▒ ▒░ ░ ░ ▒  ░    ░      ░ ▒ ▒░ ░ ░░   ░ ▒░  ░ ▒ ▒░  ░ ░  ░   ░ ░░  \r\n░  ░  ░  ░ ░ ░ ▒    ░ ░     ░      ░ ░ ░ ▒     ░   ░ ░ ░ ░ ░ ▒     ░        ░░  \r\n      ░      ░ ░      ░  ░             ░ ░           ░     ░ ░     ░  ░      ░  \r\n                                                                            ░   ");
                Console.WriteLine(" ██▓  ██████  ██ ▄█▀▓█████  ███▄    █ ▓█████▄ ▓█████  ██▀███  \r\n▓██▒▒██    ▒  ██▄█▒ ▓█   ▀  ██ ▀█   █ ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒\r\n▒██▒░ ▓██▄   ▓███▄░ ▒███   ▓██  ▀█ ██▒░██   █▌▒███   ▓██ ░▄█ ▒\r\n░██░  ▒   ██▒▓██ █▄ ▒▓█  ▄ ▓██▒  ▐▌██▒░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄  \r\n░██░▒██████▒▒▒██▒ █▄░▒████▒▒██░   ▓██░░▒████▓ ░▒████▒░██▓ ▒██▒\r\n░▓  ▒ ▒▓▒ ▒ ░▒ ▒▒ ▓▒░░ ▒░ ░░ ▒░   ▒ ▒  ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░\r\n ▒ ░░ ░▒  ░ ░░ ░▒ ▒░ ░ ░  ░░ ░░   ░ ▒░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░\r\n ▒ ░░  ░  ░  ░ ░░ ░    ░      ░   ░ ░  ░ ░  ░    ░     ░░   ░ \r\n ░        ░  ░  ░      ░  ░         ░    ░       ░  ░   ░     \r\n                                       ░                      ");
                Console.ReadKey();
                Console.ResetColor();
            }

            else if (menu.ToLower() == "edit")
            {
                int selectedElement = 0;
                bool removing = true;
                while (removing)
                {
                    Console.Clear();
                    Console.WriteLine("Select student to change grade");
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == selectedElement)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(items[i].key + " " + items[i].value);
                        Console.ResetColor();
                    }
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            {
                                Console.Clear();
                                Console.WriteLine("Write new grade (0.0-4.0):");
                                string newGrade = Console.ReadLine();
                                students[items[selectedElement].key] = newGrade;
                                removing = false;
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                selectedElement--;
                                if (selectedElement < 0)
                                {
                                    selectedElement = items.Count - 1;
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                selectedElement = (selectedElement + 1) % items.Count;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                Menu("list");
            }
        }
    }
}

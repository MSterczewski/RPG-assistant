using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace RPG_assisant
{
    class UserInterface
    {
        static void Main()
        {
            //Statistic s = new Statistic();
            //s.name = "Strength";
            //s.symbol = "STR";
            //s.limit = 10;
            //s.description = "Strength is the power of a hit";
            CreateUniverse();
            //Stream stream = File.Open("..//..//Statistic.dat", FileMode.Create);
            //BinaryFormatter bformatter = new BinaryFormatter();
            //bformatter.Serialize(stream, CreateStatistic());
            //stream.Close();
        }

        /// <summary>
        /// Function that implements user input of the statistic
        /// </summary>
        /// <returns>a new statistic</returns>
        static Statistic CreateStatistic()
        {
            Console.WriteLine("Create a statistic...\n");
            Console.WriteLine("Instruction:");
            Console.WriteLine("Symbol:\t\t Represents the symbol of the statistic e.g. STR");
            Console.WriteLine("Name:\t\t Represents the ful name of the statistic e.g. Strength ");
            Console.WriteLine("Limit:\t\t Represents the limit of the statistic in this universe e.g. 20");
            Console.WriteLine("Description:\t Contains the long description of the statistic\n");
            Statistic stat = new Statistic();
            Console.Write("Symbol: ");
            stat.symbol = Console.ReadLine();
            Console.Write("Name: ");
            stat.name = Console.ReadLine();
            Console.Write("Limit: ");
            stat.limit = int.Parse(Console.ReadLine());
            Console.Write("Description: ");
            stat.description = Console.ReadLine();
            //To do: confirmation and command line
            return stat;
        }


        static void SaveUniverse(Universe universe)
        {

        }

        static Universe CreateUniverse()
        {
            void DisplayInstruction()
            {
                Console.WriteLine("Instruction:");
                Console.WriteLine("Name:\t\t Represents the name of the universe e.g. DnD");
                Console.WriteLine("Description:\t Contains the long description of the universe");
                Console.WriteLine("Statistics:\t The list of the available statistics in the universe\n");
            }
            void DisplayCurrentUniverse(Universe uni)
            {
                Console.WriteLine("Current universe:\n");
                Console.WriteLine("Name:\t\t" + uni.name);
                Console.WriteLine("Description:\t" + uni.description);
                Console.Write("Statistics:\t");
                if (uni.statistics.Count == 0)
                {
                    Console.WriteLine("(no statistics selected)");
                    return;
                }

                foreach (Statistic stat in uni.statistics)
                    Console.Write(stat.symbol + " ");
                Console.WriteLine();
            }
            void DisplayAvailableOptions()
            {
                //to do: new (statistic), statistics clear
                Console.WriteLine("AvailableOptions: help, update, add, display, exit, clear, info");//all of them done
                Console.WriteLine("For more information about a command, please type \"help [command]\"");
            }
            void DisplayHelp(string forWhat)
            {
                switch (forWhat)
                {
                    case "clear":
                        {
                            Console.WriteLine("clear - Clears the console");
                        }
                        break;
                    case "help":
                        {
                            Console.WriteLine("help - Displays the help for the command");
                            Console.WriteLine("syntax: \"help [command]\"");
                        }
                        break;
                    case "update":
                        {
                            Console.WriteLine("update - Enables user to modify either the name, description or the statistic");
                            Console.WriteLine("syntax: \"update [what] [newValue]\"");
                        }
                        break;
                    case "add":
                        {
                            Console.WriteLine("add - Adds a statistic from a database");
                            Console.WriteLine("syntax: \"add [statistic]\"");
                            Console.WriteLine("To display available statistics in the database, please use a \"statistics\" command");
                        }
                        break;
                    case "display":
                        {
                            Console.WriteLine("display - Displays the current universe");
                        }
                        break;
                    case "exit":
                        {
                            Console.WriteLine("exit - Exits the universe creation mode");
                            Console.WriteLine("After exitting will prompt the user whether they want to save work");
                        }
                        break;
                    case "info":
                        {
                            Console.WriteLine("info - Shows information about statistic");
                            Console.WriteLine("syntax: \"info [statistic symbol]\"");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Unrecognised command name... Please try again...");
                        }
                        break;
                }
            }
            void AnalyseInput(Universe uni)
            {
                for (; ; )
                {
                    Console.Write("\tOption: ");
                    string input = Console.ReadLine();
                    Console.WriteLine();
                    switch (input.Split(' ')[0])
                    {
                        case "help":
                            {
                                if (input.Split(' ').Length == 1)
                                {
                                    DisplayAvailableOptions();
                                }
                                else
                                {
                                    DisplayHelp(input.Split(' ')[1]);
                                }
                            }
                            break;
                        case "update":
                            {
                                if (input.Split(' ').Length <= 2)
                                {
                                    Console.WriteLine("Invalid syntax");
                                    break;
                                }
                                switch (input.Split(' ')[1])
                                {
                                    case "name":
                                        {
                                            if (input.Split(' ').Length > 3)
                                            {
                                                Console.WriteLine("Invalid name length");
                                                break;
                                            }
                                            uni.name = input.Split(' ')[2];
                                            Console.WriteLine("name updated");
                                        }
                                        break;
                                    case "description":
                                        {
                                            StringBuilder s = new StringBuilder();
                                            foreach (string str in input.Split(' ').Skip(2))
                                                s.Append(str + " ");
                                            uni.description = s.Remove(s.Length - 1, 1).ToString();
                                            Console.WriteLine("description updated");
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option");
                                        }
                                        break;
                                }
                            }
                            break;
                        case "add":
                            {
                                Console.WriteLine("Adding a new statistic...");
                                Console.WriteLine("Do you want to load an existing statistic or create a new one?");
                                for (; ; )
                                {
                                    Console.Write("load/new:");
                                    string s = Console.ReadLine();
                                    if (s == "load")
                                    {
                                        Console.WriteLine("Not implemented :(");
                                        break;
                                    }
                                    if (s == "new")
                                    {
                                        newStatistic: Statistic stat = CreateStatistic();
                                        uni.statistics.Add(stat);
                                        Console.WriteLine("\nAdded " + stat.symbol);
                                        Console.WriteLine("Do you wish to create another statistic?");
                                        yesNoPrompt: Console.WriteLine("[Y/n]:");
                                        string ans = Console.ReadLine();
                                        if (ans == "Y")
                                        {
                                            goto newStatistic;
                                        }
                                        if (ans=="n")
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Invalid option");
                                        goto yesNoPrompt;
                                    }
                                    Console.WriteLine("Invalid input");
                                }
                            }
                            break;
                        case "display":
                            {
                                DisplayCurrentUniverse(uni);
                                Console.WriteLine();
                            }
                            break;
                        case "exit":
                            {
                                Console.WriteLine("Exitting...");
                                //Console.WriteLine("Current universe:");
                                DisplayCurrentUniverse(uni);
                                Console.WriteLine();
                                for (; ; )
                                {
                                    Console.WriteLine("Do you want to save this universe?");
                                    Console.Write("Type [Y/n]");
                                    string ans = Console.ReadLine();
                                    if (ans == "Y")
                                    {
                                        //save
                                        SaveUniverse(uni);
                                        return;
                                    }
                                    if (ans == "n")
                                    {
                                        uni = null;
                                        return;
                                    }
                                    Console.WriteLine("Invalid input");
                                }

                            }
                        case "clear":
                            {
                                Console.Clear();
                            }
                            break;
                        case "info":
                            {
                                if (input.Split(' ').Length != 2)
                                {
                                    Console.WriteLine("Invalid syntax");
                                    break;
                                }
                                Console.WriteLine();
                                Statistic s = uni.statistics.Find(x => x.symbol == input.Split(' ')[1]);
                                if (s == null)
                                {
                                    Console.WriteLine("Invalid statistic symbol");
                                    break;
                                }
                                s.DisplayStatistic();
                                Console.WriteLine();
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Unrecognised input...Please try again...");
                                //DisplayAvailableOptions();
                            }
                            break;
                    }

                }
            }
            Console.WriteLine("Create a universe...\n");
            DisplayInstruction();
            Universe universe = new Universe();
            Console.Write("\tName: ");
            universe.name = Console.ReadLine();
            Console.Write("\tDescription: ");
            universe.description = Console.ReadLine();
            universe.statistics = new List<Statistic>();
            Console.WriteLine();
            DisplayCurrentUniverse(universe);

            Console.WriteLine();
            DisplayAvailableOptions();
            AnalyseInput(universe);
            //Console.WriteLine("\n");
            //DisplayCurrentUniverse(universe);


            return universe;
            //To do: confirmation and command line
        }

    }
}

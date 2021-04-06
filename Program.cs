using HydraAIO.Discord;
using KeyAuth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Console = Colorful.Console;

namespace HydraAIO
{
    class Program
    {
        private static string[] string_0 = new string[26]
{
      "Sending Hits to webhook",
      "Grabbing Nudes",
      "Installing rat...",
      "Wave to camera",
      "Stealing Yo IP",
      "Yo mama so fat she fall off both sides of the bed",
      "Nice paypal password bro :kekw:",
      "Dick",
      "Get scummed",
      "https://pornhub.com/",
      "nice cock bro :))",
      "Damn u are so sexy (sike)",
      "show me ur feets",
      "ur fingers is cool",
      "u have dick head",
      "wave to ur mom ",
      "mining bitcoin",
      "Thanks for bitcoin",
      "sex me",
      "Danko skemmer",
      "Ur fat",
      "U get token grabbed ",
      "Thanks for money from paypal <3",
      "Hydra = UHQ - 'almost every customer'",
      "Damn ur cock is so small",
      "Leaking ur masturbating videos",
};

        static string name = "Hydra";
        static string ownerid = "2jo2Iq9xmM";
        static string secret = "5d1084b791994cf321233d10e277ed3ed680b4f00883c339d24ff68cbb6da7fc";
        static string version = "1.1";

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        public static List<string> pickedModulesNames = new List<string>();
        private static List<Func<string[], string, bool>> pickedModules = new List<Func<string[], string, bool>>();
        public static int hits = 0;
        public static int bad = 0;
        public static int cpm = 0;
        public static int threads = 0;
        public static int free = 0;
        public static int twofa = 0;
        public static int cheked = 0;
        public static IEnumerable<string> combos;
        public static IEnumerable<string> proxies;
        public static int combototal = 0;
        public static int proxiesCount = 0;
        public static int globalThreads = 0;
        public static int custom = 0;
        public static string proxyProtocol = "";
        public static int comboIndex = 0;
        public static int comboTotal = 0;
        public static void prefix(string prefix, string description)
        {
            Console.Write("  [", Color.White);
            Console.Write(prefix, Color.BlueViolet); // "»"
            Console.Write("] " + description, Color.White);
        }

        static void Main(string[] args) 
        {
            DiscordRPC1.Initialize();

            Console.Title = "☠ SensivityAIO | V1 ☠";
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  [", Color.White);
            Console.Write("»", Color.BlueViolet);
            Console.Write("] Connecting..", Color.White);
            KeyAuthApp.init();

            string key;
            if (!File.Exists(@"C:\ProgramData\" + name))
            {
                Console.Write("\n\n  [", Color.White);
                Console.Write("»", Color.BlueViolet);
                Console.Write("] Please enter your license key: ", Color.White);
                System.Console.ForegroundColor = ConsoleColor.White;
                key = Console.ReadLine();
                KeyAuthApp.license(key);
                Thread.Sleep(400);
                Menu0();
            }
            else
            {
                key = File.ReadAllText(@"C:\ProgramData\" + name);
                Console.Write("\n\n  [", Color.White);
                Console.Write("»", Color.BlueViolet);
                System.Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] Logging in with saved key:", Color.White);
                Console.Write(" " + key, Color.BlueViolet);
                KeyAuthApp.license(key);
                Thread.Sleep(1000);
                Menu0();
            }

            Thread.Sleep(-1);
        }

        public static void settingoptions()
        {
            Colorful.Console.Write("[", Color.WhiteSmoke);
            Colorful.Console.Write("1", Color.Red);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Color of UI");
            Colorful.Console.Write("[", Color.WhiteSmoke);
            Colorful.Console.Write("2", Color.Red);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" UI font Set");
            string optionset = Console.ReadLine();
            if (optionset == "2")
            {
                Console.Clear();
                Hydro.fontset.fontsettings();
            }
        }

        public static void checkingoptions()
        {
            Console.Clear();
            printlogo5();
            Console.WriteLineFormatted("[{0}] Yahoo         [{1}] CodeCademy", Color.BlueViolet, Color.WhiteSmoke, (object)"1", (object)"9");
            Console.WriteLineFormatted("[{0}] Netflix       [{1}] Wish", Color.BlueViolet, Color.WhiteSmoke, (object)"2", (object)"10");
            Console.WriteLineFormatted("[{0}] Mail access   [{1}] Disney+", Color.BlueViolet, Color.WhiteSmoke, (object)"3", (object)"11");
            Console.WriteLineFormatted("[{0}] Doordash      [{1}] Twitter", Color.BlueViolet, Color.WhiteSmoke, (object)"4", (object)"12");
            Console.WriteLineFormatted("[{0}] LoL EUW       ", Color.BlueViolet, Color.WhiteSmoke, (object)"5", (object)"13");
            Console.WriteLineFormatted("[{0}] AntiPublic    ", Color.BlueViolet, Color.WhiteSmoke, (object)"6", (object)"14");
            Console.WriteLineFormatted("[{0}] Instagram     ", Color.BlueViolet, Color.WhiteSmoke, (object)"7", (object)"15");
            Console.WriteLineFormatted("[{0}] Hulu          ", Color.BlueViolet, Color.WhiteSmoke, (object)"8", (object)"16");
            Console.Write("           > ", Color.WhiteSmoke);
            string option = Console.ReadLine();
            if (option == "1")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.yahoomodule.Checkyahoo(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "2")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.netflixmodule.checknetflix(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "3")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.mailaccessmodule.checkmail(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "4")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.doordashmodule.Checkdoordash(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "5")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.lolmodule.checklol(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "6")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.antipublic.checkantipublic(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "7")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.instagrammodule.checkinsta(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "8")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                Program.printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.hulumodule.hulucheck(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
            else if (option == "9")
            {
                ProxySystem.ProxySystem.startchecking();
                Console.Title = "SensivityAIO v1 - press S to start checking ";
                Console.Clear();
                printlogo5();
                Colorful.Console.Write(" > ", Color.WhiteSmoke);
                string options = System.Console.ReadLine();
                List<string> combos = new List<string>();
                List<string> proxies = new List<string>();


                foreach (string line in File.ReadLines("./combo.txt"))
                {
                    combos.Add(line.Replace("\n", ""));
                }
                foreach (string line in File.ReadLines("./proxies.txt"))
                {
                    proxies.Add(line.Replace("\n", ""));
                }
                foreach (string combo in combos)
                {
                    Modules.codecademymodule.checkcodecademy(combo);
                    Console.Clear();
                    checkingmenu();
                }

                Console.WriteLine("Finished checking!");
                System.Console.ReadKey();
            }
        }

        public static void Menu0()
        {
            DiscordRPC1.Initialize();

        menu1:
            Console.Clear();
            Console.Title = "☠ SensivityAIO v1☠";
            printlogo5();
            prefix("1", "Checker\n");
            prefix("2", "Tools\n");
            prefix("3", "Information\n");
            prefix("4", "TOS\n");
            prefix("5", "Settings\n");
            Console.WriteLine("");
            prefix("x", "Close\n");
            Console.WriteLine("");
            prefix("»", "");
            System.Console.ForegroundColor = ConsoleColor.White;
            var userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    {
                        checkingoptions();
                        break;
                    }
                case "2":
                    {
                        // the tools tab here
                        break;
                    }
                case "3":
                    {
                        // information tab here
                        break;
                    }
                case "4":
                    {
                        // Tos tab here
                        break;
                    }
                case "5":
                    {
                        // settings tab here
                        break;
                    }
                case "x":
                    {
                        // This closes the program.

                        prefix("»", "Goodbye!");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                    }
                case "X":
                    {
                        // This closes the program.

                        prefix("»", "Goodbye!");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        prefix("-", "Invalid Option.");
                        Thread.Sleep(300);
                        goto menu1;
                    }
            }

        }

        public static void printlogo5()
        {
            Console.WriteLine("                               _____                _       _ _                  _____ ____         __ ", Color.BlueViolet);
            Console.WriteLine("                              / ____|              (_)     (_) |           /\\   |_   _/ __ \\       /_ |", Color.BlueViolet);
            Console.WriteLine("                             | (___   ___ _ __  ___ ___   ___| |_ _   _   /  \\    | || |  | | __   _| |", Color.BlueViolet);
            Console.WriteLine("                              \\___ \\ / _ \\ '_ \\/ __| \\ \\ / / | __| | | | / /\\ \\   | || |  | | \\ \\ / / |", Color.BlueViolet);
            Console.WriteLine("                              ____) |  __/ | | \\__ \\ |\\ V /| | |_| |_| |/ ____ \\ _| || |__| |  \\ V /| |", Color.BlueViolet);
            Console.WriteLine("                             |_____/ \\___|_| |_|___/_| \\_/ |_|\\__|\\__, /_/    \\_\\_____\\____/    \\_/ |_|", Color.BlueViolet);
            Console.WriteLine("                                                                   __/ |                               ", Color.BlueViolet);
            Console.WriteLine("                                                                  |___/                                ", Color.BlueViolet);
            Console.WriteLine("", Color.DarkRed);
            Console.WriteLine("                            Coded by venxxi, FaxHack and _JK - \"" + Program.string_0[new Random().Next(Program.string_0.Length)] + "\"", Color.BlueViolet);
            Console.WriteLine("", Color.DarkRed);
            Console.WriteLine("", Color.DarkRed);
        }

        public static void StartCPM()
        {
            while (comboTotal > cheked)
            {
                var firstInt = Program.cheked;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var secondInt = Program.cheked;
                Program.cpm = (firstInt - secondInt) * 60;
            }
        }


        public static void checkingmenu()
        {
            Hydro.Export.savehits();
            printlogo5();
            Console.Title = "SensivityAIO [v1] | Developed by venxxi _JK and FaxHack";
            Colorful.Console.Write("                           [", Color.WhiteSmoke);
            Colorful.Console.Write("~", Color.BlueViolet);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Checked: " + cheked, Color.White);
            System.Console.WriteLine();
            Colorful.Console.Write("                           [", Color.WhiteSmoke);
            Colorful.Console.Write("~", Color.BlueViolet);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Hits: " + hits, Color.WhiteSmoke);
            Colorful.Console.Write("                           [", Color.WhiteSmoke);
            Colorful.Console.Write("~", Color.BlueViolet);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Custom: " + custom, Color.WhiteSmoke);
            Colorful.Console.Write("                           [", Color.WhiteSmoke);
            Colorful.Console.Write("~", Color.BlueViolet);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Bad: " + bad, Color.WhiteSmoke);
            Colorful.Console.Write("                           [", Color.WhiteSmoke);
            Colorful.Console.Write("~", Color.BlueViolet);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Cpm: " + cpm * 60, Color.WhiteSmoke);
            Thread.Sleep(100);
        }
    }
}

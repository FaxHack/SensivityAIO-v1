using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HydraAIO.ProxySystem
{
    internal class ProxySystem
    {
        public static int threads = -1;
        public static string proxyProtocol = "";
        private static List<Func<string[], string, bool>> pickedModules = new List<Func<string[], string, bool>>();
        public static List<string> pickedModulesNames = new List<string>();
        public static string options = "";
        public static int globalThreads = -1;
        public static int globalRetries = -1;
        public static int hits = 0;
        public static int frees = 0;
        public static int errors = 0;
        public static int cpm = 0;
        public static int checks = 0;
        public static IEnumerable<string> combos;
        public static int comboTotal = 0;
        public static IEnumerable<string> proxies;
        public static int proxiesCount = 0;
        public static int comboIndex = 0;
        public static int Modules = 0;
        public static void startchecking()
        {
            Console.Clear();
            Program.printlogo5();
            Console.Title = "HydraAIO | Start checking |";
        threadssys:
            Colorful.Console.WriteLine("> Threads: ", Color.White);
            while (threads <= 0)
            {
                try
                {
                    threads = int.Parse(Colorful.Console.ReadLine());
                }
                catch
                {
                    Colorful.Console.WriteLine("[-] Error with thread input!\n", Color.Red);
                    goto threadssys;
                }
                while (true)
                {
                    Colorful.Console.WriteLine();
                    Colorful.Console.WriteLine("> Please Pick Proxy Type: ", Color.WhiteSmoke);
                    Colorful.Console.WriteLine();
                    Colorful.Console.Write("[", Color.WhiteSmoke);
                    Colorful.Console.Write("1", Color.BlueViolet);
                    Colorful.Console.Write("]", Color.WhiteSmoke);
                    Colorful.Console.WriteLine(" Http/s", Color.White);
                    Colorful.Console.Write("[", Color.WhiteSmoke);
                    Colorful.Console.Write("2", Color.BlueViolet);
                    Colorful.Console.Write("]", Color.WhiteSmoke);
                    Colorful.Console.WriteLine(" Socks4", Color.White);
                    Colorful.Console.Write("[", Color.WhiteSmoke);
                    Colorful.Console.Write("3", Color.BlueViolet);
                    Colorful.Console.Write("]", Color.WhiteSmoke);
                    Colorful.Console.WriteLine(" Socks5", Color.White);
                    switch (Colorful.Console.ReadKey(true).KeyChar) 
                    {
                        case '1':
                            {
                                goto label_6;
                            }
                        case '2':
                            {
                                goto label_7;
                            }
                        case '3':
                            {
                                goto label_8;
                            }
                        default:
                            Colorful.Console.WriteLine("\n[-] Invalid option!\n", Color.Red);
                            continue;
                    }
                }
                        label_6:
                            proxyProtocol = "HTTP";
                            Colorful.Console.WriteLine("\n[+] Using HTTP/s proxies!\n", Color.Green);
                            goto label_10;
                        label_7:
                            proxyProtocol = "SOCKS4";
                            Colorful.Console.WriteLine("\n[+] Using Socks-4 proxies!\n", Color.Green);
                            goto label_10;
                        label_8:
                            proxyProtocol = "SOCKS5";
                            Colorful.Console.WriteLine("\n[+] Using Socks-5 proxies!\n", Color.Green);
                label_10:
                Console.Clear();
                Program.printlogo5();
                for (int index = 1; index <= threads; ++index)
                    new Thread((ThreadStart)(() =>
                    {
                        Random random = new Random();
                        while (true)
                        {
                            if (Program.comboIndex < Program.combos.Count<string>())
                            {
                                int comboIndex = Program.comboIndex;
                                Interlocked.Increment(ref Program.comboIndex);
                                string[] strArray = Program.combos.ElementAt<string>(comboIndex).Split(':');
                                string str = Program.proxies.ElementAt<string>(random.Next(Program.proxiesCount));
                                using (IEnumerator<Func<string[], string, bool>> enumerator = ((IEnumerable<Func<string[], string, bool>>)Program.pickedModulesNames).Distinct<Func<string[], string, bool>>().GetEnumerator())
                                {
                                    while (((IEnumerator)enumerator).MoveNext())
                                        enumerator.Current.Invoke(strArray, str);
                                }
                            }
                            else
                                break;
                        }
                    })).Start();
            }

        }
           
        }
    }

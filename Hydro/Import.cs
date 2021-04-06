using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HydraAIO.Hydro
{
    internal class Import
    {
        public static IEnumerable<string> proxies;
        public static IEnumerable<string> combos;
        public static int proxiesCount = 0;
        public static int comboTotal = 0;
        public static void LoadCombos()
        {
            Console.WriteLine();
            Console.WriteLine("(>) Load your wordlist", Color.White);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            string readfile = File.ReadAllText(filename);
            Program.comboTotal = Program.combos.Count<string>();
            Console.WriteLine("(>) Loaded {0} combos.", Color.White, new object[1]
            {
        (object) Program.comboTotal
            });
            Thread.Sleep(1000);
        }

        public static void LoadProxies()
        {
            Console.WriteLine();
            Console.WriteLine(">> Please Load Proxies:", Color.White);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string fileName;
            do
            {
                openFileDialog.Title = "Load Proxies";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = "Text Files|*.txt";
                openFileDialog.RestoreDirectory = true;
                int num = (int)openFileDialog.ShowDialog();
                fileName = openFileDialog.FileName;
            }
            while (!File.Exists(fileName));
            try
            {
                Program.proxies = (IEnumerable<string>)File.ReadAllLines(fileName);
            }
            catch
            {
            }
            Program.proxiesCount = Program.proxies.Count<string>();
            Console.WriteLine("(>) Loaded {0} proxies.", Color.White, new object[1]
            {
        (object) Program.proxiesCount
            });
        }
    }
}

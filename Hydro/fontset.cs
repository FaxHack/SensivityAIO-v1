using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraAIO.Hydro
{
    internal class fontset
    {
        public static void fontsettings()
        {
            Colorful.Console.Write("[", Color.WhiteSmoke);
            Colorful.Console.Write("1", Color.Red);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" ANSI shadow");
            Colorful.Console.Write("[", Color.WhiteSmoke);
            Colorful.Console.Write("2", Color.Red);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Big");
            Colorful.Console.Write("[", Color.WhiteSmoke);
            Colorful.Console.Write("3", Color.Red);
            Colorful.Console.Write("]", Color.WhiteSmoke);
            Colorful.Console.WriteLine(" Bloody");
            Console.Write("> ", Color.WhiteSmoke);
            string optionsfont = Console.ReadLine();
            if (optionsfont == "1")
            {
                Console.WriteLine("Successfully changed font!", Color.Green);
            }
            else if (optionsfont == "2")
            {
                Console.WriteLine("Successfully changed font!", Color.Green);
            }
            else if (optionsfont == "3")
            {
                Console.WriteLine("Successfully changed font!", Color.Green);
            }
            else
            {
                Console.WriteLine("Don't changed font!", Color.Red);
            }
        }
    }
}

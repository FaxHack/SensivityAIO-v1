using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HydraAIO.Hydro
{
    internal class Export
    {
        public static string date = DateTime.Now.ToString("MM-dd-yyyy H.mm");
        private static object resultLock = new object();
        public static void savehits()
        {
            Directory.CreateDirectory("Results");
            Directory.CreateDirectory("Results/" + date);

        }
        public static void AsResult(string fileName, string content)
        {
            object resultLock = Export.resultLock;
            bool flag = false;
            try
            {
                Monitor.Enter(resultLock, ref flag);
                File.AppendAllText("Results/" + date + fileName + ".txt", content + Environment.NewLine);
            }
            finally
            {
                if (flag)
                    Monitor.Exit(resultLock);
            }
        }
    }
}

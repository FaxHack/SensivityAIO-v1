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
    internal class antipublic
    {
        public static bool checkantipublic(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string username = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + username + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)WebRequest.Create("https://digibody.avast.com/v1/web/leaks");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.UserAgent = "HolaVPN/2.12 (iPhone; iOS 12.4.7; Scale/2.00)";
                request2.ContentType = "application/x-www-form-urlencoded";


                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string api = "https://digibody.avast.com/v1/web/leaks";

                if (api.Contains("domain"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    return true;
                }

                if (api.Contains("The stolen data contains"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    return true;
                }

                if (api.Contains("leak_id"))
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

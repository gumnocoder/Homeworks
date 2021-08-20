using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Homework_9
{
    class Program
    {
        static void Main()
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            string token = File.ReadAllText("token.ini");
            string startUrl = $@"https://api.telegram.org/bot{token}/";
            int update_id = 0;
            string photo = @"C:\Users\user0\source\repos\Homeworks\Homework_9\bin\Debug\netcoreapp3.1\hi.jpeg";
            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var r = wc.DownloadString(url);

                

                Console.WriteLine(r);
                //Console.ReadKey();

                var msgs = JObject.Parse(r)["result"].ToArray();
                foreach (dynamic msg in msgs)
                {
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    string userMessage = msg.message.text;
                    string userId = msg.message.from.id;
                    string userFirstName = msg.message.from.first_name;

                    string text = $"{userMessage} {userId} {userFirstName}";
                    string photoPath = "https://avatars.mds.yandex.net/get-zen_doc/1661842/pub_5ed37d71125fcf03b498cc0f_5ed37ea088bb69593a6ff34f/scale_1200";
                    Console.WriteLine(text);

                    if (userMessage.ToLower() == "привет")
                    {
                        string responseText = "Привет!";
                        //url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        //wc.DownloadString(url);
                        string tmpUrl = $"{startUrl}sendChatAction?chat_id={userId}&upload_photo={photo}";
                        //Console.WriteLine("+");
                        wc.DownloadString(tmpUrl);
                    }
                }
                Thread.Sleep(50);
            }
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;


namespace Homework_9
{
    class Program
    {
        public static string message = null;

        public static long messageChatId;

        public static string token = File.ReadAllText("token.ini");

        public static TelegramBotClient bot;

        static void Main()
        {

             //WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

             
             //string startUrl = $@"https://api.telegram.org/bot{token}/";
             //int update_id = 0;
             //string photo = @"C:\Users\user0\source\repos\Homeworks\Homework_9\bin\Debug\netcoreapp3.1\hi.jpeg";

            TelegramBotClient bot = new TelegramBotClient(token);

            void MessageListener(object sender, MessageEventArgs e)
            {
                string text = $"{DateTime.Now.ToLongTimeString()} {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

                Console.WriteLine(text);

                if (e.Message.Text == null) return;



                var message = e.Message.Text;
                Console.WriteLine(message);


                var ee = e.Message.Text.ToLower();
                if (ee == "спой")
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "ла ла ла ла");
                }    
                else if (ee == "привет" | ee == "hi")
                {

                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Привет!");
                    var Filename = "hi.jpeg";
                    var FilePath = Path.Combine(Environment.CurrentDirectory, Filename);
                    using (var stream = File.OpenRead(FilePath))
                    {
                        var r = bot.SendPhotoAsync(e.Message.Chat.Id, new InputOnlineFile(stream)).Result;
                    }
                }
                else if (ee == "опрос")
                {
                    var pollMessage = bot.SendPollAsync(
                           e.Message.Chat.Id,
                            question: "Нравится бот?",
                            options: new[]
                            {
                                                "да!",
                                                "нет"
                            }
                        );
                }
                else
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, @"Не понял ¯\_(ツ)_/¯");
                }



                //bot.SendTextMessageAsync(chatId: e.Message.Chat, text: "Hello, World!");
            }

            

            bot.OnMessage += MessageListener;

            bot.StartReceiving();

            Thread.Sleep(500);

            Console.ReadKey();

            /*while (true)
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
                        wc.DownloadString(tmpUrl);
                    }
                }
                
            }*/
        }


    }
}

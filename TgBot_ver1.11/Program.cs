using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TgBot_ver1._11;


const string ApiToken = "5156177003:AAFGMepLTciboz5oG6Yglm2usY3EchASwRc";

Main();

void Main()
{   
    TelegramBot telegramBot = new TelegramBot(ApiToken);
    Console.ReadKey();
}




using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;



static async Task Main(string[] args)
{
    string ApiToken = "5156177003:AAFGMepLTciboz5oG6Yglm2usY3EchASwRc";

    TelegramBotClient botClient = new TelegramBotClient(ApiToken);

    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken cancellationToken = cts.Token;



    var receiverOptions = new ReceiverOptions
    {
        AllowedUpdates = { }
    };


    botClient.StartReceiving(HandleUpdateAync, HandlePollingErrorAsync, receiverOptions, cancellationToken);

    Console.ReadKey();

}

static async Task HandleUpdateAync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
{

    var chatId = update.Message.Chat.Id;


    Message m = await botClient.SendTextMessageAsync
        (
           chatId,
           update.Message.Text
        );

}

static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Саша\ITVDN2db.mdf;Integrated Security=True;Connect Timeout=30
}
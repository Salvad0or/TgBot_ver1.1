using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TgBot_ver1._11.EntityClasses;

namespace TgBot_ver1._11
{
    public class TelegramBot
    {
        #region private поля

        private readonly string _token;
        private TelegramBotClient Bot;
        private CancellationTokenSource _cts;

        #endregion

        public TelegramBot(string token)
        {
            _token = token;
            Bot = new TelegramBotClient(token);
            _cts = new CancellationTokenSource();

            CancellationToken cancellationToken = _cts.Token;

            Bot.StartReceiving(UpdateHandler, PoolingHandleError);

        }

        public async Task UpdateHandler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {

            Bot tgClient;


           await using (ITVDN2dbContext context = new ITVDN2dbContext())
           {
                tgClient = (from bot in context.Bots
                           where bot.ChatId == update.Message.Chat.Id 
                           select bot).FirstOrDefault();

                if (tgClient is null)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Вас в базе нет, внести?");
                    await DataBaseHaventAClient(botClient, context, update);
                    await context.SaveChangesAsync();
                }
                else
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{update.Message.Chat.FirstName} Вы есть в базе");
                }
           }

            
        }


        private async Task DataBaseHaventAClient(ITelegramBotClient Bot, ITVDN2dbContext context, Telegram.Bot.Types.Update update)
        {
            await Bot.SendTextMessageAsync(update.Message.Chat.Id, "Добавляем");

            Bot b = new Bot
            {
                ClientId = 3,
                ChatId = update.Message.Chat.Id,

            };


            await context.Bots.AddAsync(b);

            await Bot.SendTextMessageAsync(update.Message.Chat.Id, "Успешно");

        }


        public async Task PoolingHandleError(ITelegramBotClient Bot, Exception e, CancellationToken token)
        {

        }

    }
}

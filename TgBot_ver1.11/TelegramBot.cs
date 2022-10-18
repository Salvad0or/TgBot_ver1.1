using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using TgBot_ver1._11.EntityClasses;

namespace TgBot_ver1._11
{
    public class TelegramBot
    {
        #region private поля

        private TelegramBotClient Bot {get; set; }
        private CancellationTokenSource _cts { get; set; }
        private Bot bot { get; set; }
        private bool registerFlag { get; set; } = true;

        #endregion

        public TelegramBot(string token)
        {
            Bot = new TelegramBotClient(token);
            _cts = new CancellationTokenSource();

            CancellationToken cancellationToken = _cts.Token;

            Bot.StartReceiving(UpdateHandler, PoolingHandleError);

        }

        public async Task UpdateHandler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            long chatId = update.Message.Chat.Id;
            string message = update.Message.Text;
           
            await using (Context context = new Context())
            {
                 bot = (from b in context.Bots
                           where b.ChatId == chatId
                           select b).FirstOrDefault();
            }

            if (bot is null)
            {
                if (registerFlag) 
                {
                    await botClient.SendTextMessageAsync(chatId, "Давайте Вас зарегестрируем. Введите номер телефона: ");
                    registerFlag = false;
                    return;
                }

                await MessagesHandler.AddToBaseAsync(message, chatId, botClient);

            }
            else
            {
               await MessagesHandler.WorkWithExistClient(bot, chatId, botClient);
            }
            
            
        }

        

        public async Task PoolingHandleError(ITelegramBotClient Bot, Exception e, CancellationToken token)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TgBot_ver1._11.EntityClasses;

namespace TgBot_ver1._11
{
    public static class MessagesHandler
    {
        private static bool _handlerFlag { get; set; } = false;


        /// <summary>
        /// Метод обработки нового клиента
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chatId"></param>
        /// <param name="botClient"></param>
        /// <returns></returns>
        public async static Task AddToBaseAsync(string message, long chatId, ITelegramBotClient botClient)
        {
            bool flag = int.TryParse(message, out int phone);

            if (!flag && message.Length != 11)
            {
                await botClient.SendTextMessageAsync(chatId, "Пожалуйста проверьте ввод и попробуйте еще раз");
                return;
            }

            await using (Context context = new Context())
            {
                Client client = (from c in context.Clients
                                 where c.Phone == message
                                 select c).FirstOrDefault();

                if (client is null)
                {
                    await botClient.SendTextMessageAsync(chatId, "Номер был введен корректно,но я не нашел Вас в нашей базе данных,\n " +
                                                                 "Пожалуйста обратитесь за помощью в наш магазин по адресу: \n" +
                                                                 "Проспект Раиса Беляева, ГСК Чайка 2Г. Магазин Риальный, Вам помогут\n " +
                                                                 "Номер нашего телефона: 89270482978\n " +
                                                                 "Или попробуйте еще раз.");
                    return;
                }

                else
                {

                    Bot newBot = new Bot()
                    {
                        ChatId = chatId,
                        ClientId = client.Id
                    };

                    var lastChek = (from l in context.Bots
                                    where l.ClientId == newBot.ClientId
                                    select l).FirstOrDefault();

                    if (lastChek is not null)
                    {
                        await botClient.SendTextMessageAsync(chatId, $"Уважемый {client.Fname}" +
                                                                     $"По каким-то причинам Вы уже числитесь в базе данных" +
                                                                     $"Обратитесь к нам в магазин по адресу :" +
                                                                     $"Проспект Раиса Беляева, ГСК Чайка 2Г. Магазин Риальный, Вам помогут");

                        return;
                    }


                    context.Bots.Add(newBot);
                    await context.SaveChangesAsync();

                    await botClient.SendTextMessageAsync(chatId, $"Уважаемый {client.Fname}" +
                                                                 $"Вы были успешно добавлены в базу данных" +
                                                                 $"Приветственный бонус в размере 100 рублей был зачислен.");

                }
            }



        }
    }
}

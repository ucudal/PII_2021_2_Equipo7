using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace ClassLibrary
{
    /// <summary>
    /// API de interaccion con el servicio
    /// de mensajeria Telegram.
    /// </summary>
    public class TelegramAPI
    {
        private TelegramBotClient bot;
        private string token = "2092659821:AAG2czIsf7cbrVFUianQy3rT0be785PTWC8";
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// 
        /// </summary>
        public TelegramAPI()
        {
            this.bot = new TelegramBotClient(this.token);
            this.cancellationTokenSource = new CancellationTokenSource();

            this.bot.StartReceiving(
                new DefaultUpdateHandler(this.HandleUpdateAsync, HandleErrorAsync),
                cancellationTokenSource.Token
            );

            Console.WriteLine("Telegram API online.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    MessageWrapper message = new MessageWrapper(
                        update.Message.Text,
                        MessagingService.Telegram,
                        update.Message.From.Id.ToString());
                    MessageHandler msgHandler = new MessageHandler();
                    ResponseWrapper response = await msgHandler.HandleMessage(message);
                    Console.WriteLine($"{update.Message.Text}");
                    await this.bot.SendTextMessageAsync(update.Message.Chat.Id, response.Message, ParseMode.Html);
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Handler para el caso de presentarse un error
        /// al manejar un mensaje.
        /// </summary>
        /// <param name="exception">
        /// Excepcion a manejar.
        /// </param>
        /// <param name="cancellationToken">
        /// Token de cancelacion.
        /// </param>
        /// <returns></returns>
        public Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            this.cancellationTokenSource.Cancel();
        }
    }
}
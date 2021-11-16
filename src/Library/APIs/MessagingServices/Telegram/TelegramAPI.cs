// -----------------------------------------------------------------------
// <copyright file="TelegramAPI.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ClassLibrary
{
    /// <summary>
    /// API de interaccion con el servicio
    /// de mensajeria Telegram.
    /// </summary>
    public class TelegramAPI : IDisposable
    {
        private readonly string token = "2092659821:AAG2czIsf7cbrVFUianQy3rT0be785PTWC8";
        private bool disposed;
        private TelegramBotClient bot;
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramAPI"/> class.
        /// </summary>
        public TelegramAPI()
        {
            this.bot = new TelegramBotClient(this.token);
            this.cancellationTokenSource = new CancellationTokenSource();

            this.bot.StartReceiving(
                new DefaultUpdateHandler(this.HandleUpdateAsync, HandleErrorAsync),
                this.cancellationTokenSource.Token);

            Console.WriteLine("Telegram API online.");
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
        /// <returns>
        /// Tarea de manejo de la excepcion.
        /// </returns>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            if (exception is null)
            {
                throw new ArgumentNullException(paramName: nameof(exception));
            }

            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Metodo que maneja la llegada de cada mensaje.
        /// </summary>
        /// <param name="update">
        /// Contenedor con los datos de una actualizacion.
        /// </param>
        /// <param name="cancellationToken">
        /// Realmente no lo se.
        /// </param>
        /// <returns>
        /// Tarea relacionada al manejo de una actualizacion
        /// en los mensajes de telegram.
        /// </returns>
        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update is null)
            {
                throw new ArgumentNullException(paramName: nameof(update));
            }

            if (update.Type == UpdateType.Message)
            {
                MessageWrapper message = new MessageWrapper(
                    update.Message.Text,
                    MessagingService.Telegram,
                    update.Message.From.Id.ToString(CultureInfo.InvariantCulture));
                ResponseWrapper response = await MessageHandler.HandleMessage(message).ConfigureAwait(false);
                Console.WriteLine($"{update.Message.Text}");
                await this.bot.SendTextMessageAsync(update.Message.Chat.Id, response.Message, ParseMode.Html, cancellationToken: default).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Terminar ejecucion del bot.
        /// </summary>
        public void Stop()
        {
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Descartar instancia.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Descartar instancia.
        /// </summary>
        /// <param name="disposing">
        /// Eliminando.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.cancellationTokenSource.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}
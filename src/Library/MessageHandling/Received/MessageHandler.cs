// -----------------------------------------------------------------------
// <copyright file="MessageHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Encargado de recibir un mensaje y procesar
    /// el usuario que lo envio. Ajusta el mensaje
    /// de acuerdo a la autenticacion de este.
    /// </summary>
    public static class MessageHandler
    {
        /// <summary>
        /// Metodo llamado por los puntos de contacto
        /// con las API. Procesa el usuario del mensaje,
        /// y lo altera el mensaje segun el estado de
        /// autenticacion. Luego pasa al procesamiento de
        /// comandos en espera del mensaje de respuesta, el
        /// cual es enviado al manejador de respuesta para
        /// su envio.
        /// </summary>
        /// <param name="message">
        /// Mensaje recibido.
        /// </param>
        /// <returns>
        /// Una <see cref="Task"/> con la tarea de
        /// procesar el mensaje recibido.
        /// </returns>
        public static Task<ResponseWrapper> HandleMessage(MessageWrapper message)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                MessageIsValid(message);
                UserAuthenticator.Authenticate(message);

                string commandResponse = CommandHandler.HandleMessage(message);
                stringBuilder.Append(commandResponse);

                ResponseWrapper response = new ResponseWrapper(stringBuilder.ToString(), message.Service, message.Account);
                return Task.FromResult(response);
                /*responseHandler.SendResponse(response);*/
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine($"Excepcion al recibir un mensaje: {e.Message}");
                throw;
            }
        }

        private static void MessageIsValid(MessageWrapper message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(paramName: nameof(message));
            }
        }
    }
}
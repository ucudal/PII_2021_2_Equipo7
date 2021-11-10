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
    public class MessageHandler
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
        /// <param name="message"></param>
        public Task<ResponseWrapper> HandleMessage(MessageWrapper message)
        {
            try
            {
                CommandHandler commandHandler = new CommandHandler();
                
                StringBuilder stringBuilder = new StringBuilder();
                this.MessageIsValid(message);
                UserAuthenticator.Authenticate(message);

                string commandResponse = commandHandler.HandleMessage(message);
                stringBuilder.Append(commandResponse);

                ResponseWrapper response = new ResponseWrapper(stringBuilder.ToString(), message.Service, message.Account);
                return Task.FromResult<ResponseWrapper>(response);
                //responseHandler.SendResponse(response);
            }
            catch(ArgumentNullException e)
            {
                Debug.WriteLine($"Excepcion al recibir un mensaje: {e.Message}");
                throw;
            }
        }

        private void MessageIsValid(MessageWrapper message)
        {
            if (message is null) throw new ArgumentNullException("Se intento recibir un mensaje sin ningun dato.");
        }
    }
}
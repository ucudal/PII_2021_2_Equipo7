using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Encargado de recibir un mensaje y procesar
    /// el usuario que lo envio. Ajusta el mensaje
    /// de acuerdo a la autenticacion de este.
    /// </summary>
    public class MessageHandler
    {
        private ResponseHandler responseHandler = new ResponseHandler();
        private CommandHandler commandHandler = new CommandHandler();

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
        public void HandleMessage(MessageWrapper message)
        {
            UserAuthenticator.Authenticate(message);

            StringBuilder stringBuilder = new StringBuilder();
            string commandResponse = commandHandler.HandleMessage(message);
            stringBuilder.Append(commandResponse);

            ResponseWrapper response = new ResponseWrapper(stringBuilder.ToString(), message.Service, message.Account);
            responseHandler.SendResponse(response);
        }
    }
}
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Encargada de enviar la respuesta al usuario.
    /// </summary>
    public class ResponseHandler
    {
        /// <summary>
        /// Envia el mensaje de respuesta al usuario.
        /// </summary>
        /// <param name="response">
        /// Contenedor de respuesta con el mensaje y cuenta
        /// remota precisos para el envio de la respuesta.
        /// </param>
        public void SendResponse(ResponseWrapper response)
        {
            switch (response.Service)
            {
                case MessagingService.Console:
                    Console.WriteLine(response.Message);
                    break;
                default:
                    break;
            }
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="ResponseHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Encargada de enviar la respuesta al usuario.
    /// </summary>
    public static class ResponseHandler
    {
        /// <summary>
        /// Envia el mensaje de respuesta al usuario.
        /// </summary>
        /// <param name="response">
        /// Contenedor de respuesta con el mensaje y cuenta
        /// remota precisos para el envio de la respuesta.
        /// </param>
        public static void SendResponse(ResponseWrapper response)
        {
            if (response is null)
            {
                throw new ArgumentNullException(paramName: nameof(response));
            }

            switch (response.Service)
            {
                case MessagingService.Console:
                    Console.WriteLine(response.Message);
                    break;
                default:
                    throw new NotSupportedMessagingPlataformException("Servicio de mensajeria no implementado.");
            }
        }
    }
}
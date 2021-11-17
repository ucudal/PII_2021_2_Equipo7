// -----------------------------------------------------------------------
// <copyright file="UserAuthenticator.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase que expone los metodos necesarios para
    /// procesar el usuario de un mensaje recibido.
    /// </summary>
    public static class UserAuthenticator
    {
        /// <summary>
        /// Añade informacion del usuario y su estado de registro
        /// al contenedor de mensaje recibido.
        /// </summary>
        /// <param name="message">
        /// Contenedor del mensaje enviado por el usuario.
        /// </param>
        public static void Authenticate(MessageWrapper message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(paramName: nameof(message));
            }

            DataManager dataManager = new DataManager();

            message.UserId = dataManager.Account.GetUserIdForAccount(message.Service, message.Account);
            if (message.UserId == 0)
            {
                message.UserStatus = UserStatus.Unregistered;
            }
            else
            {
               if (dataManager.User.GetUserIsSuspended(message.UserId))
               {
                   message.UserStatus = UserStatus.Suspended;
               }
               else
               {
                   message.UserStatus = UserStatus.Registered;
               }
            }
        }
    }
}
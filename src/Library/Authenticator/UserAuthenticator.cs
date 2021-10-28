using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase que expone los metodos necesarios para 
    /// procesar un
    /// </summary>
    public class UserAuthenticator
    {
        private static UserAdmin userAdmin = Singleton<UserAdmin>.Instance;

        /// <summary>
        /// Añade informacion del usuario y su estado de registro
        /// al contenedor de mensaje recibido.
        /// </summary>
        /// <param name="message">
        /// Contenedor del mensaje enviado por el usuario.
        /// </param>
        public static void Authenticate(MessageWrapper message)
        {
            List<User> users = userAdmin.Items;
            User user = userAdmin.GetByAccount(message.Service, message.Account);
            if (user is null)
            {
                message.UserId = 0;
                message.UserStatus = UserStatus.Unregistered;
            }
            else
            {
                message.UserId = user.Id;
                if (user.Deleted)
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
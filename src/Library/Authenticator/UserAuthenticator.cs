namespace ClassLibrary
{
    /// <summary>
    /// Clase que expone los metodos necesarios para 
    /// procesar un
    /// </summary>
    public class UserAuthenticator
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
            DataManager dataManager = new DataManager();

            message.UserId = dataManager.Account.GetUserIdForAccount(message.Service,message.Account);
            if(message.UserId == 0)
            {
                message.UserStatus = UserStatus.Unregistered;
            }
            else
            {
               if(dataManager.User.GetUserIsSuspended(message.UserId))
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
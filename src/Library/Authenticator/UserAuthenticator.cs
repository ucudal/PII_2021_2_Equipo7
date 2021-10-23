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

        public static void Authenticate(MessageWrapper message)
        {
            List<User> users = userAdmin.Items;
            User user = users.Find(userObj => userObj.Accounts.Exists(accountObj => accountObj.Service == message.Service && accountObj.Identifier == message.Account));
            if (user is null)
            {
                message.UserId = 0;
                message.UserStatus = UserStatus.Unregistered;
            }
            else
            {
                message.UserId = user.Id;
                if (user.Suspended)
                {
                    message.UserStatus = UserStatus.Suspended;
                }
                else
                {
                    message.UserStatus = UserStatus.Registered;
                }
            }
            //return message;
        }
    }
}
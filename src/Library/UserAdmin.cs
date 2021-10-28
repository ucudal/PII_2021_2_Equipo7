using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public class UserAdmin : DataAdmin<User>
    {
        public User GetByAccount(MessagingService service,string account)
        {
            return this.Items.Find(userObj => userObj.Accounts.Exists(accountObj => accountObj.Service == service && accountObj.Id == account));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public class UserAdmin : DataAdmin<User>
    {
        /// <summary>
        /// Verifica si un usuario
        /// esta o no suspendido.
        /// </summary>
        /// <param name="userId">
        /// Id del usuario para el
        /// cual se quiere verificar
        /// el estado de suspension.
        /// </param>
        /// <returns>
        /// Valor booleano con el
        /// estado de suspension.
        /// </returns>
        public bool GetUserIsSuspended(int userId)
        {
            ReadOnlyCollection<User> users = this.Items;
            foreach (User user in users)
            {
                if (user.Id == userId)
                {
                    return user.Suspended;
                }
            }

            return false;
        }
    }
}
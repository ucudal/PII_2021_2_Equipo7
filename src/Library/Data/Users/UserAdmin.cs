using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public sealed class UserAdmin : DataAdmin<User>
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
            IReadOnlyCollection<User> users = this.Items;
            foreach (User user in users)
            {
                if (user.Id == userId)
                {
                    return user.Suspended;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        protected override void ValidateInsert(User item)
        {
            if(item.Id != 0) throw new ValidationException("Id debe ser vacio.");
            if(item.Suspended == true) throw new ValidationException("No se puede crear un usuario suspendido.");
            if(item.Deleted == true) throw new ValidationException("No se puede crear un usuario eliminado.");
        }

        /// <inheritdoc/>
        protected override void ValidateData(User item)
        {
            if(item.FirstName is null || item.FirstName.Length == 0) throw new ValidationException("Primer nombre no puede ser vacio.");
            if(item.LastName is null || item.LastName.Length == 0) throw new ValidationException("Primer apellido no puede ser vacio.");
            if(item.Role == 0) throw new ValidationException("Usuario debe tener un rol.");
        }
    }
}
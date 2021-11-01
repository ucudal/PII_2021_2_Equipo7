using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Administrador de datos persistentes para
    /// el tipo de datos administrable de cuentas
    /// <see cref="Account" />.
    /// </summary>
    public class AccountAdmin : DataAdmin<Account>
    {
        /// <summary>
        /// Obtiene una lista de cuentas 
        /// segun el id del usuario al
        /// cual pertenecen.
        /// </summary>
        /// <param name="userId">
        /// Id del usuario por el cual
        /// realizar la busqueda.
        /// </param>
        /// <returns>
        /// Listado de cuentas.
        /// </returns>
        public ReadOnlyCollection<Account> GetByUserId(int userId)
        {
            List<Account> resultList = new List<Account>();
            ReadOnlyCollection<Account> accounts = this.Items;
            foreach (Account acc in accounts)
            {
                if (acc.UserId == userId)
                {
                    resultList.Add(acc);
                }
            }
            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene el id de usuario para 
        /// una cuenta en concreto.
        /// </summary>
        /// <param name="service">
        /// Servicio de mensajeria de la
        /// cuenta.
        /// </param>
        /// <param name="account">
        /// Identificador de la cuenta en el 
        /// servicio de mensajeria.
        /// </param>
        /// <returns>
        /// Id del usuario al que pertenece
        /// la cuenta.
        /// </returns>
        public int GetUserIdForAccount(MessagingService service, string account)
        {
            ReadOnlyCollection<Account> accounts = this.Items;
            foreach (Account acc in accounts)
            {
                if (acc.Service == service && acc.CodeInService == account)
                {
                    return acc.UserId;
                }
            }
            return 0;
        }
    }
}
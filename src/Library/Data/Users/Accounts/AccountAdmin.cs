// -----------------------------------------------------------------------
// <copyright file="AccountAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Administrador de datos persistentes para
    /// el tipo de datos administrable de cuentas
    /// <see cref="Account" />.
    /// </summary>
    public sealed class AccountAdmin : DataAdmin<Account>
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
        public IReadOnlyCollection<Account> GetByUserId(int userId)
        {
            List<Account> resultList = new List<Account>();
            IReadOnlyCollection<Account> accounts = this.Items;
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
            IReadOnlyCollection<Account> accounts = this.Items;
            foreach (Account acc in accounts)
            {
                if (acc.Service == service && acc.CodeInService == account)
                {
                    return acc.UserId;
                }
            }

            return 0;
        }

        /// <inheritdoc/>
        protected override void ValidateData(Account item)
        {
            if (item != null)
            {
                DataManager dataManager = new DataManager();
                if (item.UserId == 0 /*|| !dataManager.User.Exists(item.UserId)*/)
                {
                    throw new ValidationException("Se precisa un identificador de usuario.");
                }

                if (item.Service == MessagingService.Undefined)
                {
                    throw new ValidationException("Servicio de mensajeria es requerido.");
                }

                if (item.CodeInService is null || item.CodeInService.Length == 0)
                {
                    throw new ValidationException("Codigo en el servicio de mensajeria requerido.");
                }
            }
        }
    }
}
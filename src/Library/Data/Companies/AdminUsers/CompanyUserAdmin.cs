// -----------------------------------------------------------------------
// <copyright file="CompanyUserAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de
    /// asociaciones entre companias
    /// y usuarios.
    /// </summary>
    public sealed class CompanyUserAdmin : DataAdmin<CompanyUser>
    {
        /// <summary>
        /// Lista todos los usuarios
        /// administradores de una
        /// compania.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania por la
        /// cual buscar usuarios.
        /// </param>
        /// <returns>
        /// Listado de ids de usuarios.
        /// </returns>
        public IReadOnlyCollection<int> GetAdminUserForCompany(int companyId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyUser> compUsers = this.Items;
            foreach (CompanyUser user in compUsers)
            {
                if (user.CompanyId == companyId)
                {
                    resultList.Add(user.AdminUserId);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Encuentra la compania que es
        /// administrada por el usuario
        /// con el id provisto.
        /// </summary>
        /// <param name="userId">
        /// Id del usuario para el cual
        /// buscar su compania.
        /// </param>
        /// <returns>
        /// Id de la compania encontrada.
        /// </returns>
        public int GetCompanyForUser(int userId)
        {
            IReadOnlyCollection<CompanyUser> compUsers = this.Items;
            foreach (CompanyUser user in compUsers)
            {
                if (user.AdminUserId == userId)
                {
                    return user.CompanyId;
                }
            }

            return 0;
        }

        /// <inheritdoc/>
        protected override void ValidateData(CompanyUser item)
        {
            if (item != null)
            {
                DataManager dataManager = new DataManager();
                if (item.AdminUserId == 0/* || !dataManager.CompanyUser.Exists(item.AdminUserId)*/)
                {
                    throw new ValidationException("Requerido usuario.");
                }

                if (item.CompanyId == 0/* || !dataManager.Company.Exists(item.CompanyId)*/)
                {
                throw new ValidationException("Requerida compania.");
                }
            }
        }
    }
}
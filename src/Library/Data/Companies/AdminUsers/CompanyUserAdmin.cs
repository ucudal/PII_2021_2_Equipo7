using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de
    /// asociaciones entre companias
    /// y usuarios.
    /// </summary>
    public class CompanyUserAdmin : DataAdmin<CompanyUser>
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
        public ReadOnlyCollection<int> GetAdminUserForCompany(int companyId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<CompanyUser> compUsers = this.Items;
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
            ReadOnlyCollection<CompanyUser> compUsers = this.Items;
            foreach (CompanyUser user in compUsers)
            {
                if (user.AdminUserId == userId)
                {
                    return user.CompanyId;
                }
            }
            
            return 0;
        }
    }
}
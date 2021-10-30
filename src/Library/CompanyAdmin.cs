using System;
using System.Collections.Generic;
using System.Collections;

namespace ClassLibrary
{
    /// <summary>
    /// clase administradora de company
    /// </summary>
    public class CompanyAdmin: DataAdmin<Company>
    {

        /// <summary>
        /// encuentra el USUARIO
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns></returns>
        public Company FindAdminUser(int id)
        {

        return this.Items.Find(obj => obj.ListAdminUsers.Exists(admin => admin.Id==id));
        }
        /// <summary>
        /// de 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Company GetByName(string name)
        {
            return this.Items.Find(obj => obj.Name== name);
        }

    }

}
using System;
using System.Collections.Generic;
using System.Collections;
using ClassLibrary;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Entrepreneur.
    /// </summary>
    public class EntrepreneurAdmin: DataAdmin<Entrepreneur>
    {
        /// <summary>
        /// encontramos un emprendedor por id de user 
        /// </summary>
        /// <param name="id">id de user</param>
        /// <returns></returns>
        public Entrepreneur GetByUser(int id)
        {
            foreach (Entrepreneur item in this.Items)
            {
                if (item.User.Id== id)
                return item;


            }
            return null;
        }
    }
}

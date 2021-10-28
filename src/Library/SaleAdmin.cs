using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para administrar las ventas.
    /// </summary>
    public class SaleAdmin : DataAdmin<Sale>
    {
        public List<Sale> GetByCompanyId(int id)
        {
            return this.Items.FindAll(obj=>obj.Company.Id==id);

        }
        
    }
}
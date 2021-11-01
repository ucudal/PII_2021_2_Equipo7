using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para administrar las ventas.
    /// </summary>
    public class SaleAdmin : DataAdmin<Sale>
    {
        /// <summary>
        /// Obtiene un listado de ventas para una compania concreta.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania para la cual se le quieren encontrar todas las ventas.
        /// </param>
        /// <returns>
        /// Listado de Ids de ventas realizadas por la compania.
        /// </returns>
        public ReadOnlyCollection<int> GetSalesBySeller(int companyId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.SellerCompanyId == companyId)
                {
                    resultList.Add(sale.Id);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene un listado de ventas para una compania concreta.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania para la cual se le quieren encontrar todas las ventas.
        /// </param>
        /// <param name="itemCount">Cantidad de items por hoja.</param>
        /// <param name="page">Hoja la cual recuperar.</param>
        /// <returns>
        /// Listado de Ids de ventas realizadas por la compania.
        /// </returns>
        public ReadOnlyCollection<int> GetSalesBySeller(int companyId, int itemCount, int page)
        {
            List<Sale> resultList = new List<Sale>();
            ReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.SellerCompanyId == companyId)
                {
                    resultList.Add(sale);
                }
            }

            List<Sale> salesPage = this.GetItemPage(resultList, itemCount, page);
            return salesPage.Select(sale => sale.Id).ToList().AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene un listado de compras realizadas por un emprendedor
        /// </summary>
        /// <param name="entrepreneurId">
        /// Id del emprendedor para el cual se le quieren buscar las compras.
        /// </param>
        /// <returns>
        /// Listado de Ids de compras realizadas por el emprendedor.
        /// </returns>
        public ReadOnlyCollection<int> GetSalesByBuyer(int entrepreneurId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.BuyerEntrepreneurId == entrepreneurId)
                {
                    resultList.Add(sale.Id);
                }
            }

            return resultList.AsReadOnly();
        }


        /// <summary>
        /// Obtiene un listado de compras realizadas por un emprendedor
        /// </summary>
        /// <param name="entrepreneurId">
        /// Id del emprendedor para el cual se le quieren buscar las compras.
        /// </param>
        /// <param name="itemCount">Cantidad de items por hoja.</param>
        /// <param name="page">Hoja la cual recuperar.</param>
        /// <returns>
        /// Listado de Ids de compras realizadas por el emprendedor.
        /// </returns>
        public ReadOnlyCollection<int> GetSalesByBuyer(int entrepreneurId, int itemCount, int page)
        {
            List<Sale> resultList = new List<Sale>();
            ReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.BuyerEntrepreneurId == entrepreneurId)
                {
                    resultList.Add(sale);
                }
            }

            List<Sale> salesPage = this.GetItemPage(resultList, itemCount, page);
            return salesPage.Select(sale => sale.Id).ToList().AsReadOnly();
        }
    }
        
    
}
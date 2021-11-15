using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para administrar las ventas.
    /// </summary>
    public sealed class SaleAdmin : DataAdmin<Sale>
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
        public IReadOnlyCollection<int> GetSalesBySeller(int companyId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<Sale> sales = this.Items;
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
        public IReadOnlyCollection<int> GetSalesBySeller(int companyId, int itemCount, int page)
        {
            List<Sale> resultList = new List<Sale>();
            IReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.SellerCompanyId == companyId)
                {
                    resultList.Add(sale);
                }
            }

            IReadOnlyCollection<Sale> salesPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
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
        public IReadOnlyCollection<int> GetSalesByBuyer(int entrepreneurId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<Sale> sales = this.Items;
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
        public IReadOnlyCollection<int> GetSalesByBuyer(int entrepreneurId, int itemCount, int page)
        {
            List<Sale> resultList = new List<Sale>();
            IReadOnlyCollection<Sale> sales = this.Items;
            foreach (Sale sale in sales)
            {
                if (sale.BuyerEntrepreneurId == entrepreneurId)
                {
                    resultList.Add(sale);
                }
            }

            IReadOnlyCollection<Sale> salesPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return salesPage.Select(sale => sale.Id).ToList().AsReadOnly();
        }

        /// <inheritdoc/>
        protected override void ValidateData(Sale item)
        {
            DataManager dataManager = new DataManager();
            if(item.BuyerEntrepreneurId == 0 /*|| !dataManager.Entrepreneur.Exists(item.BuyerEntrepreneurId)*/) 
                throw new ValidationException("Requerido emprendedor valido.");
            if(item.Currency == 0) 
                throw new ValidationException("Requerida moneda.");
            if(item.DateTime == DateTime.MinValue) 
                throw new ValidationException("Requerida fecha de transaccion.");
            if(item.Price == 0) 
                throw new ValidationException("Requerido precio mayor a cero.");
            if(item.ProductCompanyMaterialId == 0 /*|| !dataManager.CompanyMaterial.Exists(item.ProductCompanyMaterialId)*/) 
                throw new ValidationException("Requerido material de empresa vendido.");
            if(item.ProductQuantity == 0) 
                throw new ValidationException("Requerida cantidad del material.");
            if(item.SellerCompanyId == 0 /*|| !dataManager.Company.Exists(item.SellerCompanyId)*/) 
                throw new ValidationException("Requerida compania vendedora.");
        }
    }
}
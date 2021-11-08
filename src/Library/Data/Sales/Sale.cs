using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Sale.
    /// </summary>
    public class Sale : IManagableData<Sale>
    {

        /// <summary>
        /// Material de empresa comprado.
        /// </summary>
        public int ProductCompanyMaterialId { get; set; }

        /// <summary>
        /// Cantidad del material comprado.
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Property de Company.
        /// </summary>
        public int SellerCompanyId { get; set; }

        /// <summary>
        /// Property de Entrepreneur.
        /// </summary>
        public int BuyerEntrepreneurId { get; set; }

        /// <inheritdoc/>
        public int Id{get; set;}

        /// <summary>
        /// Fecha de la venta.
        /// </summary>
        public DateTime DateTime{get; set;}

        /// <summary>
        /// Precio de la venta.
        /// </summary>
        public int Price{get; set;}

        /// <summary>
        /// Divisa en la que se realiza cada venta.
        /// </summary>
        public Currency Currency{get; set;}

        /// <inheritdoc/>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor de la clase Sale para definir los atributos.
        /// </summary>
        /// <param name="DateTime"></param>
        /// <param name="Price"></param>
        /// <param name="Currency"></param>
        public Sale(DateTime DateTime, int Price, Currency Currency)
        {
            this.DateTime = DateTime;
            this.Price = Price;
            this.Currency = Currency;
            this.Deleted = false;
        }

        /// <summary>
        /// Constructor vacio para la clase SaleAdmin.
        /// </summary>
        [JsonConstructor]
        public Sale()
        {
            this.Id = 0;
            this.Deleted = false;

        }


        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Sale sale=JsonSerializer.Deserialize<Sale>(json);
            this.Id=sale.Id;
            this.DateTime=sale.DateTime;
            this.Deleted=sale.Deleted;
            this.Currency=sale.Currency;
            this.Price=sale.Price;
            this.SellerCompanyId = sale.SellerCompanyId;
            this.BuyerEntrepreneurId = sale.BuyerEntrepreneurId;
            this.ProductCompanyMaterialId = sale.ProductCompanyMaterialId;
            this.ProductQuantity = sale.ProductQuantity;
        }


        /// <inheritdoc/>
        public Sale Clone()
        {
            Sale sale =new Sale();
            sale.LoadFromJson(this.ConvertToJson());
            return sale;
        }


        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    

}
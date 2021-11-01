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
        ///   Property de publication.
        /// </summary>
        public Publication Publication{get; set;}
        /// <summary>
        /// Property a la clase PublicationItem.
        /// </summary>
        public PublicationItem PublicationItem {get; set;}

        /// <summary>
        /// Property de Company.
        /// </summary>
        public Company Company{get; set;}

        /// <summary>
        /// Property de Entrepreneur.
        /// </summary>
        public Entrepreneur Entrepreneur{get; set;}
        /// <summary>
        /// Id privado de cada Sale.
        /// </summary>
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

        /// <summary>
        /// Atributo para saber si la venta esta suspendida o no.
        /// </summary>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor de la clase Sale para definir los atributos.
        /// </summary>
        /// <param name="DateTime"></param>
        /// <param name="Price"></param>
        /// <param name="Currency"></param>
        [JsonConstructor]
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
        public Sale()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            Sale sale=JsonSerializer.Deserialize<Sale>(json);
            this.Id=sale.Id;
            this.DateTime=sale.DateTime;
            this.Deleted=sale.Deleted;
            this.Currency=sale.Currency;
            this.Price=sale.Price;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Sale Clone()
        {
            Sale sale =new Sale();
            sale.LoadFromJson(this.ConvertToJson());
            return sale;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    

}
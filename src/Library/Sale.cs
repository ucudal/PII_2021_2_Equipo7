using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Sale.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Lista de materiales de la compania.
        /// </summary>
        List<CompanyMaterial> ListCompanyMaterial = new List<CompanyMaterial>();

        /// <summary>
        /// Lista de la cantidad de materiales de una compania.
        /// </summary>
        List<PublicationItem> ListQuantity = new List<PublicationItem>();

        /// <summary>
        /// Property de Company.
        /// </summary>
        public Company Company{get; set;}

        /// <summary>
        /// Property de Entrepreneur.
        /// </summary>
        public Entrepreneur Entrepreneur{get; set;}

        /// <summary>
        /// Property de Publication.
        /// </summary>
        /// <value></value>
        public Publication Publication{get;     set;}

        /// <summary>
        /// Id privado de cada Sale.
        /// </summary>
        public int Id{get; private set;}



        /// <summary>
        /// Fecha de la venta.
        /// </summary>
        DateTime DateTime{get; set;}

        /// <summary>
        /// Precio de la venta.
        /// </summary>
        int Price{get; set;}

        /// <summary>
        /// Divisa en la que se realiza cada venta.
        /// </summary>
        Currency Currency{get; set;}

        /// <summary>
        /// Atributo para saber si la venta esta suspendida o no.
        /// </summary>
        bool Suspended{get; set;}

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
            this.Suspended = false;
        }

        /// <summary>
        /// Metodo para añadir materiales a una compania.
        /// </summary>
        public void AddItem(CompanyMaterial CompanyMaterial)
        {
            if (!ListCompanyMaterial.Contains(CompanyMaterial))
            {
                ListCompanyMaterial.Add(CompanyMaterial);
            }
        }

        /// <summary>
        /// Metodo para remover materiales de una compania.
        /// </summary>
        public void RemoveItem(CompanyMaterial CompanyMaterial)
        {
            if (ListCompanyMaterial.Contains(CompanyMaterial))
            {
                ListCompanyMaterial.Remove(CompanyMaterial);
            }
        }
        

        /// <summary>
        /// Metodo para añadir la cantidad de materiales.
        /// </summary>
        public void AddQuantity(PublicationItem Quantity)
        {
            if (!ListQuantity.Contains(Quantity))
            {
                ListQuantity.Add(Quantity);
            }

        }


        /// <summary>
        /// Metodo para remover la cantidad de los materiales.
        /// </summary>
        public void RemoveQuantity(PublicationItem Quantity)
        {
            if (ListQuantity.Contains(Quantity))
            {
                ListQuantity.Remove(Quantity);
            }

        }

    }

}
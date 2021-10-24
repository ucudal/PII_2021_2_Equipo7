using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase creada para crear una publicación y publicar los materiales para vender.
    /// </summary>
    public class Publication
    {

        /// <summary>
        /// Lista de materiales de la compania.
        /// </summary>
        List<CompanyMaterial> ListCompanyMaterial = new List<CompanyMaterial>();


        /// <summary>
        /// Lista de palabras clave para encontrar facilmente publicaciones.
        /// </summary>
        List<string> KeyWords = new List<string>();


        /// <summary>
        /// Property de la clase PublicationItem.
        /// </summary>
        public PublicationItem PublicationItem {get; set;}

        /// <summary>
        /// Publication tiene una property de Company.
        /// </summary>
        public Company Company{get; set;}


        /// <summary>
        /// Id que se la da a cada publicación.
        /// </summary>
        public  int Id{get; private set;}

        /// <summary>
        /// DateTime con la fecha de activación.
        /// </summary>
        DateTime ActiveFrom{get; set;}

        /// <summary>
        /// Datetime con la fecha de desactivación de la publicación.
        /// </summary>
        DateTime ActiveUntill{get; set;}

        /// <summary>
        /// Precio de lo que se vende en la publicación, ya sea un material o varios.
        /// </summary>
        int Price{get; set;}

        /// <summary>
        /// Divisa del precio del material o materiales.
        /// </summary>
        public Currency Currency{get; set;}

        /// <summary>
        ///  Deleted sirve para saber si la publicación se borra o no.
        /// </summary>
        bool Deleted{get; set;}

        /// <summary>
        /// Constructor de la publicación para definir los atributos.
        /// </summary>
        /// <param name="ActiveFrom"></param>
        /// <param name="ActiveUntill"></param>
        /// <param name="Price"></param>
        /// <param name="Currency"></param>
        /// <param name="Deleted"></param>
        public Publication(DateTime ActiveFrom, DateTime ActiveUntill, int Price, Currency Currency, bool Deleted)
        {
            this.ActiveFrom = ActiveFrom;
            this.ActiveUntill = ActiveUntill;
            this.Price = Price;
            this.Currency = Currency;
            this.Deleted = false;
        }



        /// <summary>
        /// Metodo para añadir materiales a una compania.
        /// </summary>
        /// <param name="CompanyMaterial">Ingreso una material que la compania quiere agregar.</param>
        public void AddItem(CompanyMaterial CompanyMaterial)
        {
            if (!ListCompanyMaterial.Contains(CompanyMaterial))
            {
                ListCompanyMaterial.Add(CompanyMaterial);
            }
        }


        /// <summary>
        /// Metodo para borrar los materiales de una compania.
        /// </summary>
        /// <param name="CompanyMaterial">Ingreso una material que la compania quiere borrar.</param>
        public void RemoveItem(CompanyMaterial CompanyMaterial)
        {
            if (ListCompanyMaterial.Contains(CompanyMaterial))
            {
                ListCompanyMaterial.Remove(CompanyMaterial);
            }
        }


        /// <summary>
        /// Metodo para añadir una palabra clave del tipo string a la lista de palabras claves.
        /// </summary>
        /// <param name="KeyWord">Ingreso palabra clave.</param>
        public void AddKeyWord(string KeyWord)
        {
            if (!KeyWords.Contains(KeyWord))
            {
                KeyWords.Add(KeyWord);
            }

        }


        /// <summary>
        /// Metodo para remover palabra clave de la lista de palabras claves del tipo string.
        /// </summary>
        /// <param name="KeyWord">Ingreso palabra clave que quiero remover.</param>
        public void RemoveKeyWord(string KeyWord)
        {
            if (KeyWords.Contains(KeyWord))
            {
                KeyWords.Remove(KeyWord);
            }
        }
    }

}
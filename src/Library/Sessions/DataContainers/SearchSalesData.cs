// -----------------------------------------------------------------------
// <copyright file="SearchSalesData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class SearchSalesData
    {
        private Sale sale;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchSalesData"/>.
        /// </summary>
        public SearchSalesData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Sale Sale { get => this.sale; set => this.sale = value; }
    }
}
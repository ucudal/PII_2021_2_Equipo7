// -----------------------------------------------------------------------
// <copyright file="InsertPublicationData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertPublicationData : SearchData
    {
        private CompanyMaterial companyMaterial;
        private Publication publication;
        private DataManager dataManager = new DataManager();
        private int companyId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertPublicationData"/>.
        /// </summary>
        public InsertPublicationData()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertPublicationData"/>.
        /// </summary>
        /// <param name="searchResults">
        /// Resultados de busqueda.
        /// </param>
        /// <param name="searchPageContext">
        /// Contexto de la busqueda.
        /// </param>
        /// <param name="searchPageRoute">
        /// Ruta de la busqueda.
        /// </param>
        /// <param name="pageItemCount">
        /// Items por pagina de resultados.
        /// </param>
        public InsertPublicationData(IReadOnlyCollection<int> searchResults, string searchPageContext, string searchPageRoute, int pageItemCount = 6)
            : base(searchResults, searchPageContext, searchPageRoute, pageItemCount)
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial; set => this.companyMaterial = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Publication Publication { get => this.publication; set => this.publication = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public int CompanyId { get => this.companyId; set => this.companyId = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        /// <returns>valor del retorno .</returns>
        public override bool RunTask()
        {
            Publication pub = this.dataManager.Publication.New();
            pub.ActiveFrom = DateTime.Now;
            pub.ActiveUntil = DateTime.Now.AddYears(50);
            pub.CompanyId = this.Publication.CompanyId;
            pub.CompanyMaterialId = this.Publication.CompanyMaterialId;
            pub.CompanyLocationId = this.Publication.CompanyLocationId;
            pub.Currency = this.Publication.Currency;
            pub.Description = this.Publication.Description;
            pub.Price = this.Publication.Price;
            pub.Quantity = this.Publication.Quantity;
            pub.Title = this.Publication.Title;
            int idPub = this.dataManager.Publication.Insert(pub);

            return idPub != 0;
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="SelectCompanyLocationData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class SelectCompanyLocationData : SearchData
    {
        private int companyLocationId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
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
        public SelectCompanyLocationData(IReadOnlyCollection<int> searchResults, string searchPageContext, string searchPageRoute, int pageItemCount = 6)
            : base(searchResults, searchPageContext, searchPageRoute, pageItemCount)
        {
        }

        /// <summary>
        /// Id de la localizacion de la compania.
        /// </summary>
        public int CompanyLocationId
        {
            get => this.companyLocationId;
            set => this.companyLocationId = value;
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        /// <returns>retorna un bool.</returns>
        public override bool RunTask()
        {
            return true;
        }
    }
}
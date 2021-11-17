// -----------------------------------------------------------------------
// <copyright file="SearchPage.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Datos de una pagina de un listado.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de dato listado por la pagina.
    /// </typeparam>
    public class SearchPage<T>
        where T : IManagableData<SearchPage<T>>
    {
        private IReadOnlyCollection<T> searchResults;
        private int currentPage;
        private int pageItemCount = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPage{T}"/> class.
        /// </summary>
        public SearchPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPage{T}"/> class.
        /// </summary>
        /// <param name="searchResults">
        /// Listado de resultados completo.
        /// </param>
        /// <param name="pageItemCount">
        /// Items por pagina.
        /// </param>
        public SearchPage(IReadOnlyCollection<T> searchResults, int pageItemCount = 10)
        {
            this.searchResults = searchResults ?? throw new ArgumentNullException(paramName: nameof(searchResults));
            this.pageItemCount = pageItemCount;
        }

        /// <summary>
        /// Listado completo.
        /// </summary>
        public IReadOnlyCollection<T> SearchResults
        {
            get => this.searchResults;
        }

        /// <summary>
        /// Indice de la pagina actual.
        /// </summary>
        public int CurrentPage
        {
            get => this.currentPage;
            set => this.currentPage = value;
        }

        /// <summary>
        /// Cuenta de items por pagina.
        /// </summary>
        public int PageItemCount
        {
            get => this.pageItemCount;
            set => this.pageItemCount = value;
        }

        /// <summary>
        /// Items de la pagina especifica.
        /// </summary>
        public IReadOnlyCollection<T> PageItems
        {
            get
            {
                IList<T> results = new List<T>();
                int startIndex = this.currentPage * this.pageItemCount;
                if (!(this.searchResults.Count >= startIndex))
                {
                    for (int i = startIndex; i < (startIndex + this.pageItemCount) && i < this.searchResults.Count; i++)
                    {
                        results.Add(this.searchResults.ElementAt(i));
                    }
                }

                return results.ToList().AsReadOnly();
            }
        }
    }
}
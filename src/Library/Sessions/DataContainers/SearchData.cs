// -----------------------------------------------------------------------
// <copyright file="SearchData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Informacion de una busqueda.
    /// </summary>
    public class SearchData : ActivityData
    {
        private IReadOnlyCollection<int> searchResults;
        private int currentPage;
        private int pageItemCount;
        private string searchPageContext;
        private string searchPageRoute;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchData"/> class.
        /// </summary>
        public SearchData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchData"/> class.
        /// </summary>
        /// <param name="searchResults">
        /// Listado de resultados completo.
        /// </param>
        /// <param name="searchPageContext">
        /// Contexto del menu de busqueda.
        /// </param>
        /// <param name="searchPageRoute">
        /// Ruta del menu de busqueda.
        /// </param>
        /// <param name="pageItemCount">
        /// Items por pagina.
        /// </param>
        public SearchData(IReadOnlyCollection<int> searchResults, string searchPageContext, string searchPageRoute, int pageItemCount = 6)
        {
            this.searchResults = searchResults ?? throw new ArgumentNullException(paramName: nameof(searchResults));
            this.pageItemCount = pageItemCount;
            this.currentPage = 0;
            this.searchPageContext = searchPageContext;
            this.searchPageRoute = searchPageRoute;
        }

        /// <summary>
        /// Listado completo.
        /// </summary>
        public IReadOnlyCollection<int> SearchResults
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
        public IReadOnlyCollection<int> PageItems
        {
            get
            {
                IList<int> results = new List<int>();
                int startIndex = this.currentPage * this.pageItemCount;
                int endIndex = startIndex + this.pageItemCount;
                endIndex = endIndex > this.searchResults.Count ? this.searchResults.Count : endIndex;
                for (int i = startIndex; i < endIndex; i++)
                {
                    results.Add(this.searchResults.ElementAt(i));
                }

                return results.ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Contexto del menu de busqueda.
        /// </summary>
        public string SearchPageContext
        {
            get => this.searchPageContext;
            set => this.searchPageContext = value;
        }

        /// <summary>
        /// Ruta del menu de busqueda.
        /// </summary>
        public string SearchPageRoute
        {
            get => this.searchPageRoute;
            set => this.searchPageRoute = value;
        }

        /// <summary>
        /// Avanzar de pagina en el listado.
        /// </summary>
        public void NextPage()
        {
            int startIndex = (this.currentPage + 1) * this.pageItemCount;
            if (startIndex >= this.searchResults.Count)
            {
                this.CurrentPage = 0;
            }
            else
            {
                this.CurrentPage++;
            }
        }

        /// <summary>
        /// Avanzar de pagina en el listado.
        /// </summary>
        public void PrevPage()
        {
            if (this.CurrentPage == 0)
            {
                int prevPage = this.searchResults.Count / this.pageItemCount;
                this.CurrentPage = prevPage;
            }
            else
            {
                this.CurrentPage--;
            }
        }
    }
}
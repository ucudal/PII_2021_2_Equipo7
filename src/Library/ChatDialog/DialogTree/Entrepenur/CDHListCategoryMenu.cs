// -----------------------------------------------------------------------
// <copyright file="CDHListCategoryMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones por localidad.
    /// </summary>
    public class CDHListCategoryMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHListCategoryMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHListCategoryMenu(ChatDialogHandlerBase next)
        : base(next, "List_Category_Menu")
        {
            this.Parents.Add("Search_Category_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;
            if (session.CurrentActivity.Code != "search_by_page_entre_pubs_cat_results")
            {
                int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
                IReadOnlyCollection<int> compMats = this.DatMgr.CompanyMaterial.GetCompanyMaterialsForCategory(id);
                IReadOnlyCollection<int> publ = this.DatMgr.Publication.Items.Where(pub => compMats.Contains(pub.CompanyMaterialId)).Select(pub => pub.Id).ToList().AsReadOnly();
                SearchData search = new SearchData(publ, this.Parents.First(), this.Route)
                {
                    Query = id.ToString(CultureInfo.InvariantCulture),
                };
                activity = new UserActivity("search_by_page_entre_pubs_cat_results", "Search_Publication_Menu", "/categoria", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Resultados por Categoria</b>\n");
            builder.AppendLine($"Ingrese un id para ver detalles y/o realizar una compra.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintPublicationMaterialCategory(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron publicaciones)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(id);
                        if (matCat is not null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private string TextToPrintPublicationMaterialCategory(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int pubId in search.PageItems)
            {
                if (this.DatMgr.Publication.Exists(pubId))
                {
                    Publication pub = this.DatMgr.Publication.GetById(pubId);
                    builder.AppendLine($"{pub.Id} - {pub.Title}");
                }
            }

            return builder.ToString();
        }
    }
}
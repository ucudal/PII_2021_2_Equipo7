// -----------------------------------------------------------------------
// <copyright file="CDHSearchCategoryMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación por una categoria del material.
    /// </summary>
    public class CDHSearchCategoryMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearchCategoryMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearchCategoryMenu(ChatDialogHandlerBase next)
        : base(next, "Search_Category_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "/categoria";
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
            if (session.CurrentActivity.Code != "search_by_page_entre_pubs_cat")
            {
                IReadOnlyCollection<int> matCats = this.DatMgr.MaterialCategory.Items.OrderBy(matCat => matCat.Name).Select(matCat => matCat.Id).ToList().AsReadOnly();
                SearchData search = new SearchData(matCats, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_pubs_cat", "welcome_entrepreneur", "/buscar", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Busqueda por Categoria</b>\n");
            builder.AppendLine("Ingrese el numero de la categoria por la cual buscar.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintMaterialCategory(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron habilitaciones)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        private string TextToPrintMaterialCategory(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int matCatId in search.PageItems)
            {
                if (this.DatMgr.MaterialCategory.Exists(matCatId))
                {
                    MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(matCatId);
                    builder.AppendLine($"{matCat.Id} - {matCat.Name}");
                }
            }

            return builder.ToString();
        }
    }
}
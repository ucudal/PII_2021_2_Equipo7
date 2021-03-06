// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationListMenu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationListMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationListMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationListMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_list_menu")
        {
            this.Parents.Add("company_publication_menu");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder xListMats = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;

            if (session.CurrentActivity.Code != "search_company_publication_list_material_to_add_menu")
            {
                IReadOnlyCollection<int> publications = this.DatMgr.Publication.GetPublicationsByCompany(session.EntityId);
                SearchData search = new SearchData(publications, this.Parents.First(), this.Route);
                activity = new UserActivity("search_company_publication_list_menu", "welcome_company", "/publicaciones", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Lista de publicaciones</b>\n");
            builder.AppendLine("Ingrese el numero de la publicacion con la cual quiere trabajar.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextoToPrintPublication(data)}");
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

            builder.Append("/volver - Volver al menu de compañía.");
            return builder.ToString();
        }

        private string TextoToPrintPublication(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int matId in search.PageItems)
            {
                Publication pub = this.DatMgr.Publication.GetById(matId);
                builder.AppendLine($"{pub.Id} - {pub.Title}");
            }

            return builder.ToString();
        }
    }
}
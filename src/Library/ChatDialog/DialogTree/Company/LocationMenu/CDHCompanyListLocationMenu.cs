// -----------------------------------------------------------------------
// <copyright file="CDHCompanyListLocationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyListLocationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyListLocationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyListLocationMenu(ChatDialogHandlerBase next)
        : base(next, "company_list_location_menu")
        {
            this.Parents.Add("company_location_menu");
            this.Route = "/listar";
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
            if (session.CurrentActivity.Code != "search_by_page_company_list_location_menu")
            {
                IReadOnlyCollection<int> materials = this.DatMgr.CompanyLocation.GetLocationsForCompany(session.EntityId).Select(loc => loc.Id).ToList().AsReadOnly();
                SelectCompanyLocationData search = new SelectCompanyLocationData(materials, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_company_list_location_menu", "welcome_company", "/localizaciones", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Listado de Localizaciones</b>\n");
            builder.AppendLine("Escoja una localizacion por su id:\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintCompanyMaterial(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron materiales)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu principal de compañía.");
            return builder.ToString();
        }

        private string TextToPrintCompanyMaterial(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int locId in search.PageItems)
            {
                CompanyLocation loc = this.DatMgr.CompanyLocation.GetById(locId);
                builder.AppendLine($"{loc.Id} - {loc.GeoReference}");
            }

            return builder.ToString();
        }
    }
}
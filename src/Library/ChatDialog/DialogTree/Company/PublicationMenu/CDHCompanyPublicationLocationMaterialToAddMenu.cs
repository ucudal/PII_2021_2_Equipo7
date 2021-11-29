// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationLocationMaterialToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationLocationMaterialToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationLocationMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationLocationMaterialToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_loc_material_to_add_menu")
        {
            this.Parents.Add("company_publication_desc_material_to_add_menu");
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
            UserActivity activity = session.CurrentActivity;
            InsertPublicationData searchPast = activity.GetData<InsertPublicationData>();

            if (session.CurrentActivity.Code != "search_company_publication_list_loc_to_add_menu")
            {
                IReadOnlyCollection<int> locations = this.DatMgr.CompanyLocation.GetLocationsForCompany(session.EntityId).Select(loc => loc.Id).ToList().AsReadOnly();
                searchPast.Publication.Description = selector.Code;
                InsertPublicationData searchNew = new InsertPublicationData(locations, this.Parents.First(), this.Route)
                {
                    CompanyId = searchPast.CompanyId,
                    CompanyMaterial = searchPast.CompanyMaterial,
                    Publication = searchPast.Publication,
                };
                activity = new UserActivity("search_company_publication_list_loc_to_add_menu", "welcome_company", "/publicaciones", searchNew);
                session.CurrentActivity = activity;
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Elija la localizacion donde tiene stock del material:\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextoToPrintLocations(data)}");
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

            builder.Append("/volver - En caso de querer canclear la operacion.");
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
                    return true;
                }
            }

            return false;
        }

        private string TextoToPrintLocations(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int compLocId in search.PageItems)
            {
                CompanyLocation compLoc = this.DatMgr.CompanyLocation.GetById(compLocId);
                builder.AppendLine($"{compLoc.Id} - {compLoc.GeoReference}");
            }

            return builder.ToString();
        }
    }
}
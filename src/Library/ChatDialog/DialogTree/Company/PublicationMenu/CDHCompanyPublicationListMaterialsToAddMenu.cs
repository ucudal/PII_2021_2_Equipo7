// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationListMaterialsToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationListMaterialsToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationListMaterialsToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationListMaterialsToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_list_material_to_add_menu")
        {
            this.Parents.Add("company_publication_menu");
            this.Route = "/ingresar";
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

            if (session.CurrentActivity.Code != "company_publication_list_material_to_add_menu")
            {
            IReadOnlyCollection<int> materials = this.DatMgr.CompanyMaterial.GetCompanyMaterialsInCompany(session.EntityId);
            SearchData search = new SearchData(materials, this.Parents.First(), this.Route);
            activity = new UserActivity("company_publication_list_material_to_add_menu", "welcome_company", "/publicaciones", search);
            session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("Ingrese el numero del material que quiere añadir a la publicacion.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
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

            builder.Append("/volver - Volver al menu de compañía.");
            return builder.ToString();
        }

        private string TextToPrintCompanyMaterial(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int matId in search.PageItems)
            {
                CompanyMaterial material = this.DatMgr.CompanyMaterial.GetById(matId);
                builder.AppendLine($"{material.Id} - {material.Name}");
            }

            return builder.ToString();
        }
    }
}
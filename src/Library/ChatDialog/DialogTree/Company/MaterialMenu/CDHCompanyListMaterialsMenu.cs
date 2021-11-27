// -----------------------------------------------------------------------
// <copyright file="CDHCompanyListMaterialsMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyListMaterialsMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyListMaterialsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyListMaterialsMenu(ChatDialogHandlerBase next)
        : base(next, "company_list_material_menu")
        {
            this.Parents.Add("company_material_menu");
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
            if (session.CurrentActivity.Code != "search_company_list_material_menu")
            {
                IReadOnlyCollection<int> materials = this.DatMgr.CompanyMaterial.GetCompanyMaterialsInCompany(session.EntityId);
                SelectCompanyMaterialData search = new SelectCompanyMaterialData(materials, this.Parents.First(), this.Route);
                activity = new UserActivity("search_company_list_material_menu", "welcome_company", "/materiales", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();

            StringBuilder builder = new StringBuilder();
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre algun material ingrese su numero.\n");
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

            builder.Append("/volver - Volver al menu principal de compañía.");
            return builder.ToString();
        }

        private string TextToPrintCompanyMaterial(SelectCompanyMaterialData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int xMatId in search.PageItems)
            {
                CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(xMatId);
                builder.AppendLine($"{xMat.Id} - {xMat.Name}");
            }

            return builder.ToString();
        }
    }
}
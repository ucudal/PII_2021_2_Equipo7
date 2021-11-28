// -----------------------------------------------------------------------
// <copyright file="CDHMaterialCategoryList.cs" company="Universidad Católica del Uruguay">
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
    public class CDHMaterialCategoryList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryList(ChatDialogHandlerBase next)
        : base(next, "material_category_list")
        {
            this.Parents.Add("mat_menu");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;
            if (session.CurrentActivity.Code != "search_by_page_admin_material_category")
            {
                int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
                IReadOnlyCollection<int> compmat = this.DatMgr.CompanyMaterial.Items.Select(comp => comp.Id).ToList().AsReadOnly();

                InsertCompanyMaterialData search = new InsertCompanyMaterialData(compmat, this.Parents.First(), this.Route);
                activity = new UserActivity("comp_mat_cat_list", "welcome_sysadmin", "/materiales", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            InsertInvitationData data = activity.GetData<InsertInvitationData>();

            builder.Append("Listado de Categoria de Materiales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre alguna cat ingrese su numero.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintQualification(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron companias)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        private string TextToPrintQualification(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int compcatid in search.PageItems)
            {
                MaterialCategory comp = this.DatMgr.MaterialCategory.GetById(compcatid);
                builder.AppendLine($"{comp.Id} - {comp.Name}");
            }

            return builder.ToString();
        }
    }
}
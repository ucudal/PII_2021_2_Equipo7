// -----------------------------------------------------------------------
// <copyright file="CDHCompanyAddMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_add_menu")
        {
            this.Parents.Add("company_material_menu");
            this.Route = "/ingresar";
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
            if (session.CurrentActivity.Code != "search_by_page_company_add_menu")
            {
                IReadOnlyCollection<int> categories = this.DatMgr.MaterialCategory.GetAllCategories();
                InsertCompanyMaterialData search = new InsertCompanyMaterialData(categories, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_company_add_menu", "welcome_company", "/materiales", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            InsertCompanyMaterialData data = activity.GetData<InsertCompanyMaterialData>();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Agregar un Material</b>.\n");
            builder.AppendLine("Ingrese el numero de la categoria en la cual va el material.\n");

            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintListCategories(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron categorias)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de materiales.");
            return builder.ToString();
        }

        private string TextToPrintListCategories(InsertCompanyMaterialData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int xCatId in search.PageItems)
            {
                MaterialCategory xMat = this.DatMgr.MaterialCategory.GetById(xCatId);
                builder.AppendLine($"{xMat.Id} - {xMat.Name}");
            }

            return builder.ToString();
        }
    }
}
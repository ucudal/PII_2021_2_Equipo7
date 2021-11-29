// -----------------------------------------------------------------------
// <copyright file="CDHCompanyActionsMaterialMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyActionsMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyActionsMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyActionsMaterialMenu(ChatDialogHandlerBase next)
            : base(next, "company_actions_material_menu")
        {
            this.Parents.Add("company_list_material_menu");
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

            // UserActivity activity = new UserActivity("company_actions_material_menu", "company_material_menu", "/materiales", null);
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code,  CultureInfo.InvariantCulture));
            data.CompanyMaterial = xMat;
            data.Query = selector.Code;
            session.CurrentActivity = activity;
            MaterialCategory cat = this.DatMgr.MaterialCategory.GetById(xMat.MaterialCategoryId);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Detalles de Material</b>\n");
            builder.AppendLine($"<b>Nombre</b>: {xMat.Name}");
            builder.AppendLine($"<b>Categoria</b>: {cat.Name}\n");
            builder.AppendLine("/eliminar - Eliminar el material.");

            // builder.AppendLine("/habilitaciones - Administrar habilitaciones.\n");
            // builder.AppendLine("/stock - Administrar stock.\n");
            builder.AppendLine("/volver - Volver al menu de materiales.\n");
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
                    CompanyMaterial companyMaterial = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (companyMaterial is not null)
                    {
                        Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                        if (companyMaterial.CompanyId == session.EntityId && session.UserRole == UserRole.CompanyAdministrator)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
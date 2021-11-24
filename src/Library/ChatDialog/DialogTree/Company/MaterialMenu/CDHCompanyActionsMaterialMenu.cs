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
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code,  CultureInfo.InvariantCulture));
            data.CompanyMaterial = xMat;
            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Menu acciones sobre el material elegido.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\modificar : Modificar el material.\n");
            builder.Append("\\eliminar : Eliminar el material.\n");
            builder.Append("\\habilitaciones : Acceder a menu de habilitaciones.\n");
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
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
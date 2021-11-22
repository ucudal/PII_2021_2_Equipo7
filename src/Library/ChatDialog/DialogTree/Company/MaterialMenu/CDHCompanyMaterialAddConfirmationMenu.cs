// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyMaterialAddConfirmationMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyMaterialAddConfirmationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialAddConfirmationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialAddConfirmationMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_add_confirmation_menu")
        {
            this.Parents.Add("company_material_add_name_menu");
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
            UserActivity process = session.CurrentActivity;
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();

            CompanyMaterial companyMaterial = this.DatMgr.CompanyMaterial.New();
            companyMaterial.Name = selector.Code.Trim();
            companyMaterial.MaterialCategoryId = data.MaterialCategory.Id;
            companyMaterial.CompanyId = session.UserId;
            data.CompanyMaterial = companyMaterial;

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");
            builder.Append("Nombre: " + data.CompanyMaterial.Name);
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            bool xretorno = false;

            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    xretorno = true;
                }
            }

            return xretorno;
        }
    }
}
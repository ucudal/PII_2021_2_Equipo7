// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyEraseDataMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyEraseDataMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyEraseDataMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyEraseDataMaterialMenu(ChatDialogHandlerBase next)
        : base(next, "company_erase_data_material_menu")
        {
            this.Parents.Add("company_confirmation_erase_material_menu");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            this.EraseMaterialFromCompany(selector);
            builder.Append("Los datos se eliminaron correctamente.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }

        private void EraseMaterialFromCompany(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(data.CompanyMaterial.Id);
            xMat.Deleted = true;
            this.DatMgr.CompanyMaterial.Update(xMat);
        }
    }
}
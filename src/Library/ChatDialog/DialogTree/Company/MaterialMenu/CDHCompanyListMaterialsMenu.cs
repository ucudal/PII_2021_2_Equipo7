// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyListMaterialsMenu.cs" company="Universidad Católica del Uruguay">
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

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            builder.Append("Listado de materiales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre algun material ingrese su numero.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de materiales.\n");
            builder.Append("\\anterior: Pagina anterior de materiales.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(this.TextToPrintCompanyMaterial(selector));
            builder.Append("LISTADO_MATERIALES");
            return builder.ToString();
        }

        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            Company company = this.DatMgr.Company.GetById(this.DatMgr.CompanyUser.GetCompanyForUser(session.UserId));
            foreach (int xIdCompanyMaterial in this.DatMgr.CompanyMaterial.GetCompanyMaterialsInCompany(company.Id))
            {
                CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(xIdCompanyMaterial);
                xListMats.Append(" " + xMat.Name + " " + xMat.Id + "\n");
            }

            return xListMats.ToString();
        }
    }
}
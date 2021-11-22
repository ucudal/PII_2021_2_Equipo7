// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationListMaterialsToAddMenu.cs" company="Universidad Católica del Uruguay">
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

            StringBuilder builder = new StringBuilder();
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("Ingrese el numero del material que quiere añadir a la publicacion.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(this.TextToPrintCompanyMaterial(selector));
            builder.Append("LISTADO_MATERIALES");
            return builder.ToString();
        }

        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            Company company = this.DatMgr.Company.GetById(session.UserId);
            foreach (int i in this.DatMgr.CompanyMaterial.GetCompanyMaterialsInCompany(company.Id))
            {
                CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(i);
                xListMats.Append(" " + xMat.Name + " " + xMat.Id + "\n");
            }

            return xListMats.ToString();
        }
    }
}
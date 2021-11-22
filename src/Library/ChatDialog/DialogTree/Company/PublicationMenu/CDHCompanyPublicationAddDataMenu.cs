// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyPublicationAddDataMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationAddDataMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_add_data_menu")
        {
            this.Parents.Add("company_publication_confirmation_add_menu");
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
            this.PublicationAdd(selector);
            builder.Append("La publicacion se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }

        private void PublicationAdd(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.CompanyMaterial = data.CompanyMaterial;
            Publication xPubl = data.Publication;
            xPubl.CompanyMaterialId = data.CompanyMaterial.Id;
            xPubl.CompanyId = this.DatMgr.Company.GetById(this.DatMgr.User.GetById(session.UserId).Id).Id;
            this.DatMgr.Publication.Insert(xPubl);
        }
    }
}
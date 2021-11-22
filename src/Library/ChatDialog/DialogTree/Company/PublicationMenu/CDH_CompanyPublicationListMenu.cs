// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyPublicationListMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationListMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationListMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationListMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_list_menu")
        {
            this.Parents.Add("company_publication_menu");
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
            builder.Append("Lista de publicaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la publicacion con la cual quiere trabajar \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            builder.Append(this.TextoToPrintQualificationsToErase(selector));
            builder.Append("LISTADO_PUBLICACIONES");
            return builder.ToString();
        }

        private string TextoToPrintQualificationsToErase(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            foreach (Publication xPub in this.DatMgr.Publication.Items)
            {
                builder.Append(" " + xPub.Id + " " + this.DatMgr.CompanyMaterial.GetById(xPub.CompanyMaterialId).Name + " " + xPub.Price + "\n");
            }

            return builder.ToString();
        }
    }
}
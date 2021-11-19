// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyPublicationConfirmationEraseMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDH_CompanyPublicationConfirmationEraseMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationConfirmationEraseMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationConfirmationEraseMenu(ChatDialogHandlerBase next)
        : base(next, "company_publication_confirmation_erase_menu")
        {
            this.Parents.Add("company_publication_action_menu");
            this.Route = null;
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
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();

            builder.Append("Esta seguro que desea eliminar la publicacion del material " + this.DatMgr.CompanyMaterial.GetById(data.Publication.CompanyMaterialId).Name + " ?\n ");
            builder.Append("Esta seguro que desea eliminar la publicacion del material\n");
            builder.Append("\\confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("\\cancelar : Volver al menu de publicaciones .\n");
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
                if (!selector.Code.StartsWith('\\'))
                {
                    Publication publication = this.DatMgr.Publication.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (publication is not null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
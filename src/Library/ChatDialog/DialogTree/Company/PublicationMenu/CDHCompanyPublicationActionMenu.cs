// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationActionMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationActionMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationActionMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationActionMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_action_menu")
        {
            this.Parents.Add("company_publication_list_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            ErasePublicationData data = new ErasePublicationData();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            UserActivity process = new UserActivity("select_publication", "company_publication_menu", "/listar", data);
            data.Publication = this.DatMgr.Publication.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            session.PushActivity(process);
            process = session.CurrentActivity;
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu acciones sobre la publicacion elegido.\n");
            builder.Append("Desde este menu puede realizar la\n");
            builder.Append("siguientes operacion:\n\n");
            builder.Append("/eliminar : Eliminar la publicacion.\n");
            builder.Append("/volver : Volver a la lista de publicaciones.\n");
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
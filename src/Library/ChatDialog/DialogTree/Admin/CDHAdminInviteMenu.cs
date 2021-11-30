// -----------------------------------------------------------------------
// <copyright file="CDHAdminInviteMenu.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de la plataforma.
    /// </summary>
    public class CDHAdminInviteMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHAdminInviteMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminInviteMenu(ChatDialogHandlerBase next)
        : base(next, "invitemenu")
        {
            this.Parents.Add("welcome_sysadmin");
            this.Route = "/invitar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("admin_invite_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Generar Invitacion</b>.\n");
            builder.AppendLine("Escoja el tipo de invitacion a generar.\n");
            builder.AppendLine("/admin - A administradores.");
            builder.AppendLine("/emprendedor - A emprendedores.");
            builder.AppendLine("/compania_nueva - Como nueva compania.");
            builder.AppendLine("/compania_existente - A compania existente.\n");
            builder.Append("/volver - Volver al menu de administrador.");
            return builder.ToString();
        }
    }
}
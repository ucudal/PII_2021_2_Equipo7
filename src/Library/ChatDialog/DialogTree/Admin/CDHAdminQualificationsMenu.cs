// -----------------------------------------------------------------------
// <copyright file="CDHAdminQualificationsMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHAdminQualificationsMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHAdminQualificationsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminQualificationsMenu(ChatDialogHandlerBase next)
            : base(next, "hab_menu")
        {
            this.Parents.Add("welcome_sysadmin");
            this.Route = "/habilitaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("mat_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcionhabilitaciones .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\admin : Invitacion de administradores del sistema.\n");
            builder.Append("\\emprendedor : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\compania : Invitacion de companias al sistema.\n");
            builder.Append("\\cancelar \n");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHAdminMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHAdminMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHAdminMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminMaterialMenu(ChatDialogHandlerBase next)
        : base(next, "mat_menu")
        {
            this.Parents.Add("welcome_sysadmin");
            this.Route = "/materiales";
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
            builder.AppendLine("<b>Menu de Materiales</b>\n");
            builder.AppendLine("/agregar - Agregar materiales.");
            builder.AppendLine("/listar - Listar materiales.\n");
            builder.Append("/volver - Volver al menu de administrador.");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_Qualification_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Menu de habilitaciones.
    /// </summary>
    public class CDH_Qualification_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualification_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualification_Menu(ChatDialogHandlerBase next)
        : base(next, "Qualification_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "/habilitaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("entrepreneur_qualifications_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Menu de habilitaciones</b>.\n");
            builder.AppendLine("/eliminar - Eliminar habilitaciones.");
            builder.AppendLine("/agregar - Agregar habilitaciones.");
            builder.AppendLine("/listar - Listar habilitaciones\n");
            builder.Append("/volver - Volver al menu de emprendedor.");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_Search_Publication_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDH_Search_Publication_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_Publication_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_Publication_Menu(ChatDialogHandlerBase next)
        : base(next, "Search_Publication_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "/buscarpublicacion";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("entrepreneur_publ_search_menu", null, null, null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Busqueda de publicaciones</b>\n");
            builder.AppendLine("Que tipo de busqueda desea realizar?\n");
            builder.AppendLine("/palabraclave : Buscar publicación por palabra clave.");
            builder.AppendLine("/localidad : Buscar por localidad.");
            builder.AppendLine("/categoria : Buscar por categoria.");
            builder.Append("/volver - Volver al menu de emprendedor.");
            return builder.ToString();
        }
    }
}
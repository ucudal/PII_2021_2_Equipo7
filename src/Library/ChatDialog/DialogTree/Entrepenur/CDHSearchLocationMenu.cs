// -----------------------------------------------------------------------
// <copyright file="CDHSearchLocationMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una locación.
    /// </summary>
    public class CDHSearchLocationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearchLocationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearchLocationMenu(ChatDialogHandlerBase next)
        : base(next, "Search_Location_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "/localidad";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("entrepreneur_publ_search_location", "welcome_entrepreneur", "/buscar", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Busqueda por Localidad</b>\n");
            builder.AppendLine("Ingrese una direccion por la cual buscar.\n");
            builder.AppendLine("[localidad] - Direccion a buscar.\n");
            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }
    }
}
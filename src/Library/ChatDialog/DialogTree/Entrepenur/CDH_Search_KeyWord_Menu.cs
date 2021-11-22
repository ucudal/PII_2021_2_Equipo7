// -----------------------------------------------------------------------
// <copyright file="CDHSearchKeyWordMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una palabra clave.
    /// </summary>
    public class CDHSearchKeyWordMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearchKeyWordMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearchKeyWordMenu(ChatDialogHandlerBase next)
        : base(next, "Search_KeyWord_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "/palabraclave";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("entrepreneur_publ_search_keyword", "welcome_entrepreneur", "/buscar", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Busqueda por Palabra Clave</b>\n");
            builder.AppendLine("Ingrese la palabra clave por la cual buscar.\n");
            builder.AppendLine("[palabra clave] - Palabra clave.\n");
            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }
    }
}
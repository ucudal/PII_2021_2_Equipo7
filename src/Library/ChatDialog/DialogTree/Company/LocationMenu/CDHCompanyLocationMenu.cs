// -----------------------------------------------------------------------
// <copyright file="CDHCompanyLocationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyLocationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyLocationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyLocationMenu(ChatDialogHandlerBase next)
        : base(next, "company_location_menu")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/localizaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("company_location_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Menu de Localizaciones</b>.\n");
            builder.AppendLine("/ingresar - Agregar localizacion.");
            builder.AppendLine("/listar - Listar localizaciones.\n");
            builder.Append("/volver - Volver al menu de empresa.");
            return builder.ToString();
        }
    }
}
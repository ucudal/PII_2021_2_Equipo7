// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_menu")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/publicaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("company_publication_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu de publicaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\ingresar : Ingresar una nueva publicacion.\n");
            builder.Append("\\listar : Listar todas las publicaciones que ya posee.\n");
            return builder.ToString();
        }
    }
}
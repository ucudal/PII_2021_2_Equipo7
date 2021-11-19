// -----------------------------------------------------------------------
// <copyright file="CDH_WelcomeEntrepreneur.cs" company="Universidad Católica del Uruguay">
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
    /// emprendedor.
    /// </summary>
    public class CDH_WelcomeEntrepreneur : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_WelcomeEntrepreneur"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeEntrepreneur"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeEntrepreneur(ChatDialogHandlerBase next)
            : base(next, "welcome_entrepreneur")
        {
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            User user = this.DatMgr.User.GetById(session.UserId);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"<b>Bienvenido a PieTech {user.FirstName} {user.LastName}!</b>\n");
            builder.AppendLine("Como emprendedor usted puede realizar las siguientes acciones:\n");
            builder.AppendLine("/buscar - Buscar publicaciones.");
            builder.AppendLine("/regeneracion - Regeneración de materiales.");
            builder.AppendLine("/compras - Historial de compras.");
            builder.Append("/habilitaciones - Menú de habilitaciones.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            User user = this.DatMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user?.Role == UserRole.Entrepreneur)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
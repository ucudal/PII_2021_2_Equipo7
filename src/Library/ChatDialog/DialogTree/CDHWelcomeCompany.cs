// -----------------------------------------------------------------------
// <copyright file="CDHWelcomeCompany.cs" company="Universidad Católica del Uruguay">
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
    public class CDHWelcomeCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHWelcomeCompany"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHWelcomeCompany(ChatDialogHandlerBase next)
            : base(next, "welcome_company")
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
            builder.AppendLine("Como empresa usted puede realizar las siguientes acciones:\n");
            builder.AppendLine("/materiales - Administrar materiales.");
            builder.AppendLine("/localizaciones - Administrar localizaciones.");
            builder.AppendLine("/publicaciones - Administrar publicaciones.");
            builder.Append("/ventas - Ver ventas.");

            // builder.Append("/usuarios - Administrar usuarios.");
            // builder.Append("/seguimiento - Materiales vendidos.");
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
            if (selector.Code == "/welcome" && user?.Role == UserRole.CompanyAdministrator)
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
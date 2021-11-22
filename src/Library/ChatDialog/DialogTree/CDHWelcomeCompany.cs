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
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es administrador de una empresa.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\materiales : Administrar materiales.\n");
            builder.Append("\\publicaciones : Administrar sus publicaciones.\n");
            builder.Append("\\ventas : Manejar sus ventas.\n");
            builder.Append("\\usuarios : Administrar los usuarios administradores.");
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
// -----------------------------------------------------------------------
// <copyright file="CDH_WelcomeSysAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="CDH_WelcomeSysAdmin"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_WelcomeSysAdmin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeSysAdmin(ChatDialogHandlerBase next)
            : base(next, "welcome_sysadmin")
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
            builder.AppendLine("Como administrador de empresa usted puede realizar las siguientes acciones:\n");
            builder.AppendLine("/invitar - Invitar usuarios.");
            builder.AppendLine("/habilitaciones - Habilitaciones.");
            builder.Append("/materiales - Categorias de Materiales.");
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
            if (selector.Code == "/welcome" && user?.Role == UserRole.SystemAdministrator)
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
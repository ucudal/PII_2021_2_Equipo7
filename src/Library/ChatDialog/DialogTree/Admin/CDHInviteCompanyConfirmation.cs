// -----------------------------------------------------------------------
// <copyright file="CDHInviteCompanyConfirmation.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de la plataforma.
    /// </summary>
    public class CDHInviteCompanyConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteCompanyConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteCompanyConfirmation(ChatDialogHandlerBase next)
        : base(next, "invite_company_confirm")
        {
            this.Parents.Add("invitemenu");
            this.Route = "/compania_nueva";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            InsertInvitationData data = new InsertInvitationData();
            Invitation inv = this.DatMgr.Invitation.New();
            inv.Type = RegistrationType.CopmanyNew;
            data.Invitation = inv;
            UserActivity process = new UserActivity("company_invite", "welcome_sysadmin", "/invitar", data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Esta por generar una invitacion para una nueva empresa.\n");
            builder.AppendLine("/confirmar - Confirmar la operacion.");
            builder.Append("/volver - Volver al menu de invitaciones.");
            return builder.ToString();
        }
    }
}
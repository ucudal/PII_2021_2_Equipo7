// -----------------------------------------------------------------------
// <copyright file="CDHInviteCompanyCreate.cs" company="Universidad Católica del Uruguay">
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
    public class CDHInviteCompanyCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteCompanyCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteCompanyCreate(ChatDialogHandlerBase next)
        : base(next, "invite_company_create")
        {
            this.Parents.Add("invite_company_confirm");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertInvitationData data = process.GetData<InsertInvitationData>();
            data.RunTask();

            Invitation invitation = this.DatMgr.Invitation.GetById(data.GeneratedId);
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Se ha generado la siguiente invitacion: <b>{invitation.Code}</b>. Recuerde enviarselo al usuario final.\n");
            builder.Append("/volver - Volver al menu de invitaciones.\n");
            return builder.ToString();
        }
    }
}
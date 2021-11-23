// -----------------------------------------------------------------------
// <copyright file="CDHInviteEntrepreneurConfirmation.cs" company="Universidad Católica del Uruguay">
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
    public class CDHInviteEntrepreneurConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteEntrepreneurConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteEntrepreneurConfirmation(ChatDialogHandlerBase next)
        : base(next, "invite_entre_confirm")
        {
            this.Parents.Add("invitemenu");
            this.Route = "/emprendedor";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type = RegistrationType.EntrepreneurNew;
            UserActivity process = new UserActivity("entrepreneur_invite", null, this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;

            StringBuilder builder = new StringBuilder();

            builder.Append("Desea crear una invitacion para una compania nueva\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
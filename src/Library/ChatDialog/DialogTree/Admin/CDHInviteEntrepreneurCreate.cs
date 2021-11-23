// -----------------------------------------------------------------------
// <copyright file="CDHInviteEntrepreneurCreate.cs" company="Universidad Católica del Uruguay">
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
    public class CDHInviteEntrepreneurCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteEntrepreneurCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteEntrepreneurCreate(ChatDialogHandlerBase next)
        : base(next, "invite_company_create")
        {
            this.Parents.Add("invite_entre_confirm");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            this.QualificationAdd(selector);
            builder.Append("La invitacion se ha creado satisfactorimente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu.\n");
            return builder.ToString();
        }

        private void QualificationAdd(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertInvitationData data = process.GetData<InsertInvitationData>();
            Invitation invitation = data.Invitation;
            this.DatMgr.Invitation.Insert(invitation);
        }
    }
}
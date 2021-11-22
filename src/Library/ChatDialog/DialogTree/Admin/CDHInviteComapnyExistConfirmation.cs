// -----------------------------------------------------------------------
// <copyright file="CDHInviteComapnyExistConfirmation.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHInviteComapnyExistConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteComapnyExistConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteComapnyExistConfirmation(ChatDialogHandlerBase next)
        : base(next, "invite_companyexist_confirm")
        {
            this.Parents.Add("invite_company_exist_list");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type = RegistrationType.CompanyJoin;
            data.Invitation.CompanyId = int.Parse(selector.Code,  CultureInfo.InvariantCulture);
            DProcessData process = new DProcessData("companyexist_invite", this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;

            StringBuilder builder = new StringBuilder();

            builder.Append("Desea crear una invitacion para una compania nueva\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
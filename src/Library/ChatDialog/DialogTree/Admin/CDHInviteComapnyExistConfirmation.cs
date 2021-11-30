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

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            InsertInvitationData data = activity.GetData<InsertInvitationData>();
            Invitation inv = this.DatMgr.Invitation.New();
            inv.Type = RegistrationType.CompanyJoin;
            inv.CompanyId = int.Parse(selector.Code, CultureInfo.InvariantCulture);
            data.Invitation = inv;
            session.CurrentActivity = activity;

            Company comp = this.DatMgr.Company.GetById(data.Invitation.CompanyId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Esta por generar una invitacion para un nuevo administrador de la empresa {comp.Name}.\n");
            builder.AppendLine("/confirmar - Confirmar la operacion.");
            builder.Append("/volver - Volver al menu de invitaciones.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        Company company = this.DatMgr.Company.GetById(id);
                        if (company is not null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
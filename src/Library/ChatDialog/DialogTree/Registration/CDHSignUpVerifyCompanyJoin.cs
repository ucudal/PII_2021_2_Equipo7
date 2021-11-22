// -----------------------------------------------------------------------
// <copyright file="CDHSignUpVerifyCompanyJoin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso de un codigo de invitacion
    /// para unirse a una empresa, y le pide al usuario
    /// verificar que esta es la accion deseada.
    /// </summary>
    public class CDHSignUpVerifyCompanyJoin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpVerifyCompanyJoin"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpVerifyCompanyJoin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpVerifyCompanyJoin(ChatDialogHandlerBase next)
            : base(next, "registration_invite_comp_join")
        {
            this.Parents.Add("registration_invite");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            SignUpDataCompanyJoin data = new SignUpDataCompanyJoin(selector.Account, selector.Service)
            {
                Type = RegistrationType.CompanyJoin,
                InviteCode = selector.Code,
            };
            UserActivity activity = new UserActivity("registration", null, "/inicio", data);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion le permite ingresar como administrador de una empresa ya existente.\n\n");
            builder.Append("/confirmar - Usar el codigo\n");
            builder.Append("/cancelar - Cancelar registro.");
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
                    Invitation invite = this.DatMgr.Invitation.GetByCode(selector.Code);
                    if (invite is not null)
                    {
                        if (invite.Type == RegistrationType.CompanyJoin)
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
// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpVerifyCompanyNew.cs" company="Universidad Católica del Uruguay">
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
    /// para nueva empresa, y le pide al usuario
    /// verificar que esta es la accion deseada.
    /// </summary>
    public class CDH_SignUpVerifyCompanyNew : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpVerifyCompanyNew"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpVerifyCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpVerifyCompanyNew(ChatDialogHandlerBase next)
            : base(next, "registration_invite_comp_new")
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

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SignUpData data = process.GetData<SignUpData>();
            data.Type = RegistrationType.CopmanyNew;
            data.InviteCode = selector.Code;

            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion le permite ingresar como una nueva empresa.\n\n");
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
                 if (!selector.Code.StartsWith('\\'))
                {
                    Invitation invite = this.DatMgr.Invitation.GetByCode(selector.Code);
                    if (invite is not null)
                    {
                        if (invite.Type == RegistrationType.CopmanyNew)
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
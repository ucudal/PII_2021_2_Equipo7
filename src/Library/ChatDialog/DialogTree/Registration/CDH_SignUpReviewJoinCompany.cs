// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpReviewJoinCompany.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del oficio de la
    /// empresa. Le pide al usuario revisar los datos
    /// ingresados y confirmar su ingreso al sistema.
    /// </summary>
    public class CDH_SignUpReviewJoinCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpReviewJoinCompany"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpReviewJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpReviewJoinCompany(ChatDialogHandlerBase next)
            : base(next, "Sign_Review_Join_Company")
        {
            this.Parents.Add("registration_user_l_name");
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
            User user = data.User;
            user.LastName = selector.Code.Trim();

            Invitation invitation = this.DatMgr.Invitation.GetByCode(data.InviteCode);
            Company company = this.DatMgr.Company.GetById(invitation.CompanyId);
            StringBuilder builder = new StringBuilder();
            builder.Append("Antes de completar el proceso de registro, por favor verifique los datos ingresados.\n\n");
            builder.Append($"<b>1er Nombre</b>: {user.FirstName}\n");
            builder.Append($"<b>1er Apellido</b>: {user.LastName}\n");
            builder.Append($"<b>Empresa</b>: {company.Name}\n");
            builder.Append($"<b>Oficio</b>: {company.Trade}\n\n");
            builder.Append("/confirmar - Completar el registro.\n");
            builder.Append("/cancelar - Abandonar el registro.\n");
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
                    Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                    if (session.Process.GetData<SignUpData>()?.Type == RegistrationType.CompanyJoin)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
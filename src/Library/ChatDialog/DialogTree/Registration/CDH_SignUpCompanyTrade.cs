// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpCompanyTrade.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del nombre de la
    /// empresa a agregar. Procede a pedirle al
    /// usuario introducir el oficio de la Empresa.
    /// </summary>
    public class CDH_SignUpCompanyTrade : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpCompanyTrade"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpCompanyTrade"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpCompanyTrade(ChatDialogHandlerBase next)
            : base(next, "registration_new_comp_trade")
        {
            this.Parents.Add("registration_new_comp_name");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Company company = this.DatMgr.Company.New();
            company.Name = selector.Code;

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            SignUpDataCompanyNew data = activity.GetData<SignUpDataCompanyNew>();

            data.Company = company;

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el oficio de su <b>empresa</b>.");
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
                    return true;
                }
            }

            return false;
        }
    }
}
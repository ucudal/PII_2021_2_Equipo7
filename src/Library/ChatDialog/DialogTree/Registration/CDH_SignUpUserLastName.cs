// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpUserLastName.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del primer nombre
    /// del usuario y continua pidiendole el apellido.
    /// </summary>
    public class CDH_SignUpUserLastName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpUserLastName"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpUserLastName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpUserLastName(ChatDialogHandlerBase next)
            : base(next, "registration_user_l_name")
        {
            this.Parents.Add("registration_user_f_name");
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

            User user = this.DatMgr.User.New();
            user.FirstName = selector.Code.Trim();
            data.User = user;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese su <b>primer apellido</b>");
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
                    return true;
                }
            }

            return false;
        }
    }
}
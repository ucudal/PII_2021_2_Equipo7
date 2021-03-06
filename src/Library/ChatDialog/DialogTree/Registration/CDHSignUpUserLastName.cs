// -----------------------------------------------------------------------
// <copyright file="CDHSignUpUserLastName.cs" company="Universidad Católica del Uruguay">
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
    public class CDHSignUpUserLastName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpUserLastName"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpUserLastName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpUserLastName(ChatDialogHandlerBase next)
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
            UserActivity activity = session.CurrentActivity;
            SignUpData data = activity.GetData() as SignUpData;

            User user = this.DatMgr.User.New();
            user.FirstName = selector.Code.Trim();
            data.User = user;

            session.CurrentActivity = activity;

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
                if (!selector.Code.StartsWith('/'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
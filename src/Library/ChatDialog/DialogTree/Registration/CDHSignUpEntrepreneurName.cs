// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpEntrepreneurName.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del apellido del
    /// usuario cuando el registro es para una nuevo
    /// empresa. Procede a pedirle al usuario el nombre
    /// de la empresa a ingresar.
    /// </summary>
    public class CDHSignUpEntrepreneurName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpEntrepreneurName"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpEntrepreneurName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpEntrepreneurName(ChatDialogHandlerBase next)
            : base(next, "registration_new_entre_name")
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
            UserActivity activity = session.CurrentActivity;
            SignUpDataEntrepreneurNew data = activity.GetData<SignUpDataEntrepreneurNew>();

            User user = data.User;
            user.LastName = selector.Code.Trim();

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el <b>nombre</b> de su emprendimiento.");
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
                    Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                    if (typeof(SignUpData).IsAssignableFrom(session.CurrentActivity.TypeOfData))
                    {
                        SignUpData data = session.CurrentActivity.GetData() as SignUpData;
                        if (data.Type == RegistrationType.EntrepreneurNew)
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
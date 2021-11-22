// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpEntrepreneurAddress.cs" company="Universidad Católica del Uruguay">
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
    public class CDHSignUpEntrepreneurAddress : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpEntrepreneurAddress"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpEntrepreneurAddress"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpEntrepreneurAddress(ChatDialogHandlerBase next)
            : base(next, "registration_new_entre_addr")
        {
            this.Parents.Add("registration_new_entre_trade");
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

            Entrepreneur entrepreneur = data.Entrepreneur;
            entrepreneur.Trade = selector.Code;

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la <b>direccion</b> de su emprendimiento.");
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
// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpReviewEntrepreneurNew.cs" company="Universidad Católica del Uruguay">
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
    public class CDHSignUpReviewEntrepreneurNew : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpReviewEntrepreneurNew"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpReviewEntrepreneurNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpReviewEntrepreneurNew(ChatDialogHandlerBase next)
            : base(next, "registration_new_entre_verify")
        {
            this.Parents.Add("registration_new_entre_addr");
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
            entrepreneur.GeoReference = selector.Code;
            User user = data.User;

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Antes de completar el proceso de registro, por favor verifique los datos ingresados.\n\n");
            builder.Append($"<b>1er Nombre</b>: {user.FirstName}\n");
            builder.Append($"<b>1er Apellido</b>: {user.LastName}\n");
            builder.Append($"<b>Emprendimiento</b>: {entrepreneur.Name}\n");
            builder.Append($"<b>Oficio</b>: {entrepreneur.Trade}\n\n");
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
                if (!selector.Code.StartsWith('/'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
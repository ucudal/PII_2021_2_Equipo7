// -----------------------------------------------------------------------
// <copyright file="CDHSignUpDoneCompanyNew.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de una nueva
    /// empresa. Ingresa los datos al sistema.
    /// </summary>
    public class CDHSignUpDoneCompanyNew : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpDoneCompanyNew"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpDoneCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpDoneCompanyNew(ChatDialogHandlerBase next)
            : base(next, "registration_new_comp_end")
        {
            this.Parents.Add("registration_new_comp_verify");
            this.Route = "/confirmar";
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
            ActivityData data = activity.GetData<SignUpDataCompanyNew>();

            data.RunTask();

            session.CurrentActivity.Terminate(chainInitiator: false);

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n");
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
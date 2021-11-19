// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpDoneEntrepreneurNew.cs" company="Universidad Católica del Uruguay">
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
    public class CDH_SignUpDoneEntrepreneurNew : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpDoneEntrepreneurNew"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneEntrepreneurNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneEntrepreneurNew(ChatDialogHandlerBase next)
            : base(next, "registration_new_entre_end")
        {
            this.Parents.Add("registration_new_entre_verify");
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
            ActivityData data = activity.GetData<SignUpDataEntrepreneurNew>();

            data.RunTask();

            session.CurrentActivity.Terminate(chainInitiator: true);

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n");
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
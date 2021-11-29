// -----------------------------------------------------------------------
// <copyright file="CDHSignUpDoneJoinCompany.cs" company="Universidad Católica del Uruguay">
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
    /// ingresados en el registro de un usiario
    /// a una compañía ya existente. Ingresa los
    /// datos al sistema.
    /// </summary>
    public class CDHSignUpDoneJoinCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpDoneJoinCompany"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpDoneJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpDoneJoinCompany(ChatDialogHandlerBase next)
            : base(next, "registration_Done_join_Company")
        {
            this.Parents.Add("Sign_Review_Join_Company");
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
            ActivityData data = activity.GetData<SignUpDataCompanyJoin>();

            data.RunTask();

            session.CurrentActivity.Terminate(chainInitiator: false);

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n");
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
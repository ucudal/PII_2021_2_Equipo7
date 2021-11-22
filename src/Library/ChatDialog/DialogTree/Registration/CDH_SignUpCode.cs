// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpCode.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio del proceso de registro.
    /// Le pide al usuario introducir su codigo de
    /// registro.
    /// </summary>
    public class CDHSignUpCode : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpCode"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpCode"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpCode(ChatDialogHandlerBase next)
            : base(next, "registration_invite")
        {
            this.Parents.Add("registration_prompt");
            this.Route = "/registrar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese su <b>codigo de invitacion</b>.");
            return builder.ToString();
        }
    }
}
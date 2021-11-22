// -----------------------------------------------------------------------
// <copyright file="CDHWelcomeUnregistered.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// no registrado en la plataforma.
    /// </summary>
    public class CDHWelcomeUnregistered : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHWelcomeUnregistered"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeUnregistered"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHWelcomeUnregistered(ChatDialogHandlerBase next)
            : base(next, "registration_prompt")
        {
            this.Route = "/welcome";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<b>Bienvenido a PieTech!</b>\n\nUso de esta plataforma requiere una invitacion. ");
            builder.Append("Si usted tiene un codigo de invitacion, por favor ingrese el siguiente commando:\n\n");
            builder.Append("/registrar");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            User user = this.DatMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
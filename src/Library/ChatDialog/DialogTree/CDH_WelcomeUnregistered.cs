// -----------------------------------------------------------------------
// <copyright file="CDH_WelcomeUnregistered.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// no registrado en la plataforma.
    /// </summary>
    public class CDH_WelcomeUnregistered : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_WelcomeUnregistered"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeUnregistered"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeUnregistered(ChatDialogHandlerBase next)
            : base(next, "registration_prompt")
        {
            this.Route = "/registration";
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
    }
}
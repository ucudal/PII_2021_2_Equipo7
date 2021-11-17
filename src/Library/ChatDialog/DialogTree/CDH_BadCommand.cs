// -----------------------------------------------------------------------
// <copyright file="CDH_BadCommand.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// ChatDialogHandler concreto:
    /// Responde a un comando incorrecto.
    /// </summary>
    public class CDH_BadCommand : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_BadCommand"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_BadCommand"/>.
        /// </summary>
        public CDH_BadCommand()
            : base(null, "bad_command")
        {
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string NextLink(ChatDialogSelector selector)
        {
            return this.Execute(selector);
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            return "Commando invalido, intente de nuevo.";
        }
    }
}
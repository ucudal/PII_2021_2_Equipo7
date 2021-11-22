namespace ClassLibrary
{
    /// <summary>
    /// ChatDialogHandler concreto:
    /// Responde a un comando incorrecto.
    /// </summary>
    public class CDHBadCommand : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHBadCommand"/>.
        /// </summary>
        public CDHBadCommand() : base(null, "bad_command")
        {
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Next(ChatDialogSelector selector)
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
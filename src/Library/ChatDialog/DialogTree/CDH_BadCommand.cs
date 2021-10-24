namespace ClassLibrary
{
    /// <summary>
    /// ChatDialogHandler concreto:
    /// Responde a un comando incorrecto.
    /// </summary>
    public class CDH_BadCommand : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_BadCommand"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_BadCommand(ChatDialogHandlerBase next) : base(next, "bad_command")
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
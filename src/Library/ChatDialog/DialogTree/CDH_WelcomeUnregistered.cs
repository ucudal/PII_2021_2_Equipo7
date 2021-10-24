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
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeUnregistered"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeUnregistered(ChatDialogHandlerBase next) : base(next, "registration_prompt")
        {
            this.route = "\\registration";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Bienvenido! Uso de esta plataforma requiere una invitacion.\n");
            builder.Append("Si usted tiene un codigo de invitacion, por favor ingrese el\ncommando '\\registrar'.");
            return builder.ToString();
        }
    }
}
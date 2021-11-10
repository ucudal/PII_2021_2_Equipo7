using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// no registrado en la plataforma.
    /// </summary>
    public class CDH_SessionExpired : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SessionExpired"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SessionExpired(ChatDialogHandlerBase next) : base(next, "session_expired_alert")
        {
            this.parents.Add("session_expired");
            this.route = "/resetsession";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);

            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Su sesion ha caducado.");
            builder.Append("Volviendo al inicio.");
            return builder.ToString();
        }
    }
}
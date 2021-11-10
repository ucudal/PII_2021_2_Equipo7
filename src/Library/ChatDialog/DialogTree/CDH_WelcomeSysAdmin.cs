using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_WelcomeSysAdmin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeSysAdmin(ChatDialogHandlerBase next) : base(next, "welcome_sysadmin")
        {}

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es administrador del sistema.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\invitar : Invitar usuarios.\n");
            builder.Append("\\usuarios : Administrar los usuarios de la plataforma.\n");
            builder.Append("\\materiales : Administrar categorias de materiales.");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            User user = this.datMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user.Role == UserRole.SystemAdministrator)
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
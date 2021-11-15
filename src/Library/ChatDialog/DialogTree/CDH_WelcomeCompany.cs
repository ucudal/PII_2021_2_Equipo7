using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_WelcomeCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeCompany(ChatDialogHandlerBase next) : base(next, "welcome_company")
        {}

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es administrador de una empresa.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("/materiales : Administrar materiales.\n");
            builder.Append("/publicaciones : Administrar sus publicaciones.\n");
            builder.Append("/ventas : Manejar sus ventas.\n");
            builder.Append("/usuarios : Administrar los usuarios administradores.");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            User user = this.datMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user.Role == UserRole.CompanyAdministrator)
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
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// emprendedor.
    /// </summary>
    public class CDH_WelcomeEntrepreneur : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeEntrepreneur"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeEntrepreneur(ChatDialogHandlerBase next) : base(next, "welcome_entrepreneur")
        {}

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es un emprendedor.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\busqueda : Buscar materiales.\n");
            builder.Append("\\compras : Revisar sus compras.\n");
            builder.Append("\\habilitaciones : Administrar sus habilitaciones.");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            User user = this.userAdmin.GetById(session.UserId);
            if (selector.Code == "\\welcome" && user.Role == UserRole.Entrepreneur)
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
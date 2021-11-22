using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// emprendedor.
    /// </summary>
    public class CDHWelcomeEntrepreneur : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeEntrepreneur"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHWelcomeEntrepreneur(ChatDialogHandlerBase next) : base(next, "welcome_entrepreneur")
        {}

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es un emprendedor.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\buscarpublicacion : Buscar publicaciones.\n");
            builder.Append("\\regeneracionmaterial : Muestra la regeneración del material.\n");
            builder.Append("\\historialcompras: Mostrar historial de compra.");
            builder.Append("\\habilitaciones: Menú de habilitaciones.");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            User user = this.datMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user.Role == UserRole.Entrepreneur)
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
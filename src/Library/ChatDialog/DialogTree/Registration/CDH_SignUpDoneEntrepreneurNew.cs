using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de una nueva
    /// empresa. Ingresa los datos al sistema.
    /// </summary>
    public class CDH_SignUpDoneEntrepreneurNew : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;
        private EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneEntrepreneurNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneEntrepreneurNew(ChatDialogHandlerBase next) : base(next, "registration_new_entre_end")
        {
            this.parents.Add("registration_new_entre_verify");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            Account account = new Account(selector.Service, selector.Account);
            User user = data.User;
            user.Id = 1;
            user.Role = UserRole.Entrepreneur;
            user.Accounts.Add(account);
            Entrepreneur entrepreneur = data.Entrepreneur;
            entrepreneur.Id = 1;
            //entrepreneur.AddUser(user);

            userAdmin.Insert(user);
            entrepreneurAdmin.Insert(entrepreneur);
            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.");
            builder.Append("\nPara continuar ingrese el commando '\\inicio'.");
            return builder.ToString();
        }
    }
}
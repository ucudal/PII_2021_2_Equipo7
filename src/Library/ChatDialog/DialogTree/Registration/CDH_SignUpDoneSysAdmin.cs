using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de un nuevo 
    /// administrador de la plataforma. Ingresa los
    /// datos al sistema.
    /// </summary>
    public class CDH_SignUpDoneSysAdmin : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler</param>
        public CDH_SignUpDoneSysAdmin(ChatDialogHandlerBase next) : base(next, "registration_join_sysadmin_end")
        {
            this.parents.Add("registration_join_sysadmin_verify");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            Account account = new Account();
            account.Service = selector.Service;
            account.Identifier = selector.Account;
            User user = data.User;
            user.Id = 1;
            user.Role = UserRole.SystemAdministrator;
            user.Accounts.Add(account);

            bool isOk = userAdmin.Insert(user);
            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.");
            builder.Append("\nPara continuar ingrese el commando '\\inicio'.");
            return builder.ToString();
        }
    }
}
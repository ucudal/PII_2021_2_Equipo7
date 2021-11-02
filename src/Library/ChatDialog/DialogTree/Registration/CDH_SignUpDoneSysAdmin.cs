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
        private AccountAdmin accAdmin = Singleton<AccountAdmin>.Instance;
        private InvitationAdmin invAdmin = Singleton<InvitationAdmin>.Instance;

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
           
            User user = userAdmin.New();
            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Role = UserRole.SystemAdministrator;
            int userId = userAdmin.Insert(user);

            if (userId != 0)
            {
                Account acc = accAdmin.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                accAdmin.Insert(acc);

                Invitation invite = invAdmin.GetByCode(data.InviteCode);
                invite.Used = true;
                invAdmin.Update(invite);
            }

            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.");
            builder.Append("\nPara continuar ingrese el commando '\\inicio'.");
            return builder.ToString();
        }
    }
}
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
    public class CDHSignUpDoneSysAdmin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpDoneSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler</param>
        public CDHSignUpDoneSysAdmin(ChatDialogHandlerBase next) : base(next, "registration_join_sysadmin_end")
        {
            this.parents.Add("registration_join_sysadmin_verify");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
           
            User user = this.datMgr.User.New();
            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Role = UserRole.SystemAdministrator;
            int userId = this.datMgr.User.Insert(user);

            if (userId != 0)
            {
                Account acc = this.datMgr.Account.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                this.datMgr.Account.Insert(acc);

                Invitation invite = this.datMgr.Invitation.GetByCode(data.InviteCode);
                invite.Used = true;
                this.datMgr.Invitation.Update(invite);
            }

            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n"); 
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
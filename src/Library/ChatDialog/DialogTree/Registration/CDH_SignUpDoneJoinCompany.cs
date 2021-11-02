using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de un usiario  
    /// a una compañía ya existente. Ingresa los
    /// datos al sistema.
    /// </summary>
    public class CDH_SignUpDoneJoinCompany : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;
        private AccountAdmin accAdmin = Singleton<AccountAdmin>.Instance;
        private InvitationAdmin inviteAdmin = Singleton<InvitationAdmin>.Instance;
        private CompanyUserAdmin compUsrAdmin = Singleton<CompanyUserAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler</param>
        public CDH_SignUpDoneJoinCompany(ChatDialogHandlerBase next) : base(next, "registration_Done_join_Company")
        {
            this.parents.Add("Sign_Review_Join_Company");
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
            user.Role = UserRole.CompanyAdministrator;
            int userId = userAdmin.Insert(user);

            if (userId != 0)
            {
                Account acc = accAdmin.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                accAdmin.Insert(acc);
                
                Invitation inv = inviteAdmin.GetByCode(data.InviteCode);

                if (inv.CompanyId != 0)
                {
                    CompanyUser compUsr = compUsrAdmin.New();
                    compUsr.CompanyId = inv.CompanyId;
                    compUsr.AdminUserId = userId;
                    compUsrAdmin.Insert(compUsr);
                }

                inv.Used = true;
                inviteAdmin.Update(inv);
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
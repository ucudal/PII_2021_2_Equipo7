using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de un nuevo 
    /// a una compañía ya existente. Ingresa los
    /// datos al sistema.
    /// </summary>
    public class CDH_SingUpDoneJoinCompany : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;

        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;

        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SingUpDoneJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler</param>
        public CDH_SingUpDoneJoinCompany(ChatDialogHandlerBase next) : base(next, "registration_Done_join_Company")
        {
            this.parents.Add("Sign_Review_Join_Company");
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
            user.Role = UserRole.SystemAdministrator;
            user.Accounts.Add(account);

            userAdmin.Insert(user);
            Invitation invitation = invitationAdmin.GetByCode(data.InviteCode);
            Company company = companyAdmin.GetById(invitation.CompanyId);
            company.AddAdminUser(user);
            companyAdmin.Update(company);
            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.");
            builder.Append("\nPara continuar ingrese el commando '\\inicio'.");
            return builder.ToString();
        }
    }
}
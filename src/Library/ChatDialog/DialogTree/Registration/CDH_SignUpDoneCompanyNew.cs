using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de una nueva
    /// empresa. Ingresa los datos al sistema.
    /// </summary>
    public class CDH_SignUpDoneCompanyNew : ChatDialogHandlerBase
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneCompanyNew(ChatDialogHandlerBase next) : base(next, "registration_new_comp_end")
        {
            this.parents.Add("registration_new_comp_verify");
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
            user.Role = UserRole.CompanyAdministrator;
            user.Accounts.Add(account);
            Company company = data.Company;
            company.Id = 1;
            company.AddAdminUser(user);

            bool isOk = userAdmin.Insert(user);
            isOk = companyAdmin.Insert(company);
            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.");
            builder.Append("\nPara continuar ingrese el commando '\\inicio'.");
            return builder.ToString();
        }
    }
}
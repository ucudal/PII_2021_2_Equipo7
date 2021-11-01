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
                private AccountAdmin accAdmin = Singleton<AccountAdmin>.Instance;
        private CompanyUserAdmin compUsrAdmin = Singleton<CompanyUserAdmin>.Instance;

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
            }
        
            Company comp = companyAdmin.New();
            comp.Name = data.Company.Name;
            comp.Trade = data.Company.Trade;
            int compId = companyAdmin.Insert(comp);

            if (compId != 0)
            {
                CompanyUser compUsr = compUsrAdmin.New();
                compUsr.CompanyId = compId;
                compUsr.AdminUserId = userId;
                compUsrAdmin.Insert(compUsr);
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
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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneCompanyNew(ChatDialogHandlerBase next) : base(next, "registration_new_comp_end")
        {
            this.parents.Add("registration_new_comp_verify");
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
            user.Role = UserRole.CompanyAdministrator;
            user.Suspended = false;
            int userId = this.datMgr.User.Insert(user);

            if (userId != 0)
            {
                Company comp = this.datMgr.Company.New();
                comp.Name = data.Company.Name;
                comp.Trade = data.Company.Trade;
                int compId = this.datMgr.Company.Insert(comp);

                Account acc = this.datMgr.Account.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                this.datMgr.Account.Insert(acc);

                if (compId != 0)
                {
                    CompanyUser compUsr = this.datMgr.CompanyUser.New();
                    compUsr.CompanyId = compId;
                    compUsr.AdminUserId = userId;
                    this.datMgr.CompanyUser.Insert(compUsr);
                }

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
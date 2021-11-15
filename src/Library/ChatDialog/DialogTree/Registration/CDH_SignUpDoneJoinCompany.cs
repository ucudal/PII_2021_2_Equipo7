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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler</param>
        public CDH_SignUpDoneJoinCompany(ChatDialogHandlerBase next) : base(next, "registration_Done_join_Company")
        {
            this.parents.Add("Sign_Review_Join_Company");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.PopProcess();
            SignUpData data = process.GetData<SignUpData>();

            User user = this.datMgr.User.New();
            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Role = UserRole.CompanyAdministrator;
            int userId = this.datMgr.User.Insert(user);

            if (userId != 0)
            {
                Account acc = this.datMgr.Account.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                this.datMgr.Account.Insert(acc);
                
                Invitation inv = this.datMgr.Invitation.GetByCode(data.InviteCode);

                if (inv.CompanyId != 0)
                {
                    CompanyUser compUsr = this.datMgr.CompanyUser.New();
                    compUsr.CompanyId = inv.CompanyId;
                    compUsr.AdminUserId = userId;
                    this.datMgr.CompanyUser.Insert(compUsr);
                }

                inv.Used = true;
                this.datMgr.Invitation.Update(inv);
            }

            session.MenuLocation = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n"); 
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneEntrepreneurNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneEntrepreneurNew(ChatDialogHandlerBase next) : base(next, "registration_new_entre_end")
        {
            this.parents.Add("registration_new_entre_verify");
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
            user.Role = UserRole.Entrepreneur;
            int userId = this.datMgr.User.Insert(user);

            if (userId != 0)
            {
                Account acc = this.datMgr.Account.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                this.datMgr.Account.Insert(acc);

                Entrepreneur entre = this.datMgr.Entrepreneur.New();
                entre.Name = data.Entrepreneur.Name;
                entre.Trade = data.Entrepreneur.Trade;
                entre.UserId = userId;
                int entreId = this.datMgr.Entrepreneur.Insert(entre);

                Invitation invite = this.datMgr.Invitation.GetByCode(data.InviteCode);
                invite.Used = true;
                this.datMgr.Invitation.Update(invite);
            }

            session.MenuLocation = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n"); 
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
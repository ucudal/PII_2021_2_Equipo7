using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del oficio de la
    /// empresa. Le pide al usuario revisar los datos 
    /// ingresados y confirmar su ingreso al sistema.
    /// </summary>
    public class CDH_SignUpReviewJoinCompany : ChatDialogHandlerBase
    {
        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;

        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpReviewJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpReviewJoinCompany(ChatDialogHandlerBase next) : base(next, "Sign_Review_Join_Company")
        {
            this.parents.Add("registration_user_l_name");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SignUpData data = process.GetData<SignUpData>();
            User user = data.User;
            user.LastName = selector.Code.Trim();

            Invitation invitation = invitationAdmin.GetByCode(data.InviteCode);
            Company company = companyAdmin.GetById(invitation.CompanyId);
            StringBuilder builder = new StringBuilder();
            builder.Append("Segun los datos ingresados su nombre\n");
            builder.Append($"es {user.FirstName} {user.LastName}, y su\n");
            builder.Append($"empresa se llama {company.Name} que\n");
            builder.Append($"trabaja en el oficio de {company.Trade}.\n");
            builder.Append("Si estos datos son correctos, confirme el\n");
            builder.Append("registro con el commando '\\confirmar'\n");
            builder.Append("Si no son correctos, ingrese '\\cancelar'");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
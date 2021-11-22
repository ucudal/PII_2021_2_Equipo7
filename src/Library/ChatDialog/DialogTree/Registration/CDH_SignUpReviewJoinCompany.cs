using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del oficio de la
    /// empresa. Le pide al usuario revisar los datos 
    /// ingresados y confirmar su ingreso al sistema.
    /// </summary>
    public class CDHSignUpReviewJoinCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpReviewJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpReviewJoinCompany(ChatDialogHandlerBase next) : base(next, "Sign_Review_Join_Company")
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

            Invitation invitation = this.datMgr.Invitation.GetByCode(data.InviteCode);
            Company company = this.datMgr.Company.GetById(invitation.CompanyId);
            StringBuilder builder = new StringBuilder();
            builder.Append("Antes de completar el proceso de registro, por favor verifique los datos ingresados.\n\n");
            builder.Append($"<b>1er Nombre</b>: {user.FirstName}\n");
            builder.Append($"<b>1er Apellido</b>: {user.LastName}\n");
            builder.Append($"<b>Empresa</b>: {company.Name}\n");
            builder.Append($"<b>Oficio</b>: {company.Trade}\n\n");
            builder.Append("/confirmar - Completar el registro.\n");
            builder.Append("/cancelar - Abandonar el registro.\n");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    Session session = this.sessions.GetSession(selector.Service, selector.Account);
                    if (session.Process.GetData<SignUpData>()?.Type == RegistrationType.CompanyJoin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
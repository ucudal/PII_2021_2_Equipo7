using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del oficio de la
    /// empresa. Le pide al usuario revisar los datos 
    /// ingresados y confirmar su ingreso al sistema.
    /// </summary>
    public class CDHSignUpReviewCompanyNew : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpReviewCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpReviewCompanyNew(ChatDialogHandlerBase next) : base(next, "registration_new_comp_verify")
        {
            this.parents.Add("registration_new_comp_trade");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            Company company = data.Company;
            company.Trade = selector.Code;
            User user = data.User;

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
                    return true;
                }
            }
            return false;
        }
    }
}
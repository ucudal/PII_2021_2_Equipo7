using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del nombre de la
    /// empresa a agregar. Procede a pedirle al
    /// usuario introducir el oficio de la Empresa.
    /// </summary>
    public class CDH_SignUpCompanyTrade : ChatDialogHandlerBase
    {
        CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpCompanyTrade"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpCompanyTrade(ChatDialogHandlerBase next) : base(next, "registration_new_comp_trade")
        {
            this.parents.Add("registration_new_comp_name");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Company company = companyAdmin.New();
            company.Name = selector.Code;

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            data.Company = company;

            StringBuilder builder = new StringBuilder();
            builder.Append("Por ultimo, ingrese el oficio de su empresa:");
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
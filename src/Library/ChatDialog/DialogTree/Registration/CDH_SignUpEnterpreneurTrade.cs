using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del nombre de la
    /// empresa a agregar. Procede a pedirle al
    /// usuario introducir el oficio de la Empresa.
    /// </summary>
    public class CDH_SignUpEnterpreneurTrade : ChatDialogHandlerBase
    {
        EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpEnterpreneurTrade"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpEnterpreneurTrade(ChatDialogHandlerBase next) : base(next, "registration_new_entre_trade")
        {
            this.parents.Add("registration_new_entre_name");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Entrepreneur entrepreneur = entrepreneurAdmin.New();
            entrepreneur.Name = selector.Code;

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            data.Entrepreneur = entrepreneur;

            StringBuilder builder = new StringBuilder();
            builder.Append("Por ultimo, ingrese el oficio de su emprendimiento:");
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
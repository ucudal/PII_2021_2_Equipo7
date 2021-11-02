using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del oficio de la
    /// empresa. Le pide al usuario revisar los datos 
    /// ingresados y confirmar su ingreso al sistema.
    /// </summary>
    public class CDH_SignUpReviewEntrepreneurNew : ChatDialogHandlerBase
    {
        EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpReviewEntrepreneurNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpReviewEntrepreneurNew(ChatDialogHandlerBase next) : base(next, "registration_new_entre_verify")
        {
            this.parents.Add("registration_new_entre_trade");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            Entrepreneur entrepreneur = data.Entrepreneur;
            entrepreneur.Trade = selector.Code;
            User user = data.User;

            StringBuilder builder = new StringBuilder();
            builder.Append("Segun los datos ingresados su nombre\n");
            builder.Append($"es {user.FirstName} {user.LastName}, y su\n");
            builder.Append($"empresa se llama {entrepreneur.Name} que\n");
            builder.Append($"trabaja en el oficio de {entrepreneur.Trade}.\n");
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
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del apellido del
    /// usuario cuando el registro es para una nuevo
    /// empresa. Procede a pedirle al usuario el nombre
    /// de la empresa a ingresar.
    /// </summary>
    public class CDH_SignUpEnterpreneurName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpEnterpreneurName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpEnterpreneurName(ChatDialogHandlerBase next) : base(next, "registration_new_entre_name")
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

            StringBuilder builder = new StringBuilder();
            builder.Append("Ahora vamos a ingresar los datos de su emprendimiento.\n");
            builder.Append("Primero ingrese el nombre de la empresa:");
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
                    if (session.Process.GetData<SignUpData>()?.Type == RegistrationType.EntrepreneurNew)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
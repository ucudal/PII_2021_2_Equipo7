using System;
using System.Diagnostics;
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
    public class CDHSignUpCompanyName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpCompanyName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpCompanyName(ChatDialogHandlerBase next) : base(next, "registration_new_comp_name")
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
            builder.Append("Ingrese el nombre de su <b>empresa</b>.");
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
                    if (session.Process.GetData<SignUpData>()?.Type == RegistrationType.CopmanyNew)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
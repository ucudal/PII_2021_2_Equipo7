using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio del proceso de registro.
    /// Le pide al usuario introducir su codigo de
    /// registro.
    /// </summary>
    public class CDH_SignUpCode : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpCode"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpCode(ChatDialogHandlerBase next) : base(next, "registration_invite")
        {
            this.parents.Add("registration_prompt");
            this.route = "\\registrar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            SignUpData signUpData = new SignUpData(selector.Account, selector.Service);
            DProcessData process = new DProcessData("registration", this.code, signUpData);

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese su codigo de invitacion:");
            return builder.ToString();
        }
    }
}
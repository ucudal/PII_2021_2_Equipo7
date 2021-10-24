using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del apellido del
    /// usuario cuando el registro es para un nuevo
    /// administrador de la plataforma. Le pide al
    /// usuario revisar los datos ingresados y confirmar
    /// el ingreso al sistema.
    /// </summary>
    public class CDH_SignUpReviewSysAdmin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpReviewSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpReviewSysAdmin(ChatDialogHandlerBase next) : base(next, "registration_join_sysadmin_verify")
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
            builder.Append("Segun los datos ingresados su nombre\n");
            builder.Append($"es {user.FirstName} {user.LastName}.\n");
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
                    Session session = this.sessions.GetSession(selector.Service, selector.Account);
                    if (session.Process.GetData<SignUpData>()?.Type == RegistrationType.SystemAdminJoin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
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
            DProcessData process = session.CloneCurrentProcess();
            SignUpData data = process.GetData<SignUpData>();
            User user = data.User;
            user.LastName = selector.Code.Trim();

            StringBuilder builder = new StringBuilder();
            builder.Append("Antes de completar el proceso de registro, por favor verifique los datos ingresados.\n\n");
            builder.Append($"<b>1er Nombre</b>: {user.FirstName}\n");
            builder.Append($"<b>1er Apellido</b>: {user.LastName}\n");
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
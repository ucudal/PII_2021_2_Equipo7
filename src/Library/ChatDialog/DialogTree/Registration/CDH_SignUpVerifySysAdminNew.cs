using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso de un codigo de invitacion
    /// para nuevo administrador de la plataforma, y
    /// le pide al usuario verificar que esta es la 
    /// accion deseada.
    /// </summary>
    public class CDH_SignUpVerifySysAdminNew : ChatDialogHandlerBase
    {
        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpVerifySysAdminNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpVerifySysAdminNew(ChatDialogHandlerBase next) : base(next, "registration_invite_sysadmin_join")
        {
            this.parents.Add("registration_invite");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SignUpData data = process.GetData<SignUpData>();
            data.Type = RegistrationType.SystemAdminJoin;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion le permite ingresar\ncomo un administrador de la plataforma.\n");
            builder.Append("Si esto es correcto, ingrese el comando '\\confirmar'.\n");
            builder.Append("De caso contrario ingrese '\\cancelar'.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                 if (!selector.Code.StartsWith('\\'))
                {
                    Invitation invite = this.invitationAdmin.GetById(selector.Code);
                    if (invite is not null)
                    {
                        if (invite.Type == RegistrationType.SystemAdminJoin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
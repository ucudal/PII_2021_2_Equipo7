using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso de un codigo de invitacion
    /// para nueva empresa, y le pide al usuario
    /// verificar que esta es la accion deseada.
    /// </summary>
    public class CDH_SignUpVerifyCompanyNew : ChatDialogHandlerBase
    {
        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpVerifyCompanyNew"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpVerifyCompanyNew(ChatDialogHandlerBase next) : base(next, "registration_invite_comp_new")
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
            data.Type = RegistrationType.CopmanyNew;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion le permite ingresar como una nueva empresa.\n");
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
                        if (invite.Type == RegistrationType.CopmanyNew)
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
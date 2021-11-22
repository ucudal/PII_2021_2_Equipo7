using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_InviteCompanyConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_InviteCompanyConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_InviteCompanyConfirmation(ChatDialogHandlerBase next) : base(next, "invite_company_confirm")
        {   this.Parents.Add("invitemenu");
            this.Route = "/compania_nueva" ;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type= RegistrationType.CopmanyNew;
            DProcessData process = new DProcessData("company_invite", this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;

            StringBuilder builder = new StringBuilder();

            builder.Append("Desea crear una invitacion para una compania nueva\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();

        }

    }
}
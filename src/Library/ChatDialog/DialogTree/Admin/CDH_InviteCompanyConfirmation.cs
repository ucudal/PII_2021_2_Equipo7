using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHInviteCompanyConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteCompanyConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteCompanyConfirmation(ChatDialogHandlerBase next) : base(next, "invite_company_confirm")
        {   this.parents.Add("invitemenu");
            this.route = "/compania_nueva" ;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type= RegistrationType.CopmanyNew;
            DProcessData process = new DProcessData("company_invite", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;

            StringBuilder builder = new StringBuilder();

            builder.Append("Desea crear una invitacion para una compania nueva\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();

        }

    }
}
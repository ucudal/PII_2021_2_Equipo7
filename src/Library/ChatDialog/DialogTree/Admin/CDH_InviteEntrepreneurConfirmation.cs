using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHInviteEntrepreneurConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteEntrepreneurConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteEntrepreneurConfirmation(ChatDialogHandlerBase next) : base(next, "invite_entre_confirm")
        {   this.parents.Add("invitemenu");
            this.route = "/emprendedor" ;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type= RegistrationType.EntrepreneurNew;
            DProcessData process = new DProcessData("entrepreneur_invite", this.code, data);
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
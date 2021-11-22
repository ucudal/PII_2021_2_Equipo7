using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHInviteAdminCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteAdminCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteAdminCreate(ChatDialogHandlerBase next) : base(next, "invite_admin_create")
        {
            this.parents.Add("invite_admin_confirm");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            QualificationAdd(selector);
            builder.Append("La invitacion se ha creado satisfactorimente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu.\n");
            return builder.ToString();
        }
        
        private void QualificationAdd(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertInvitationData data = process.GetData<InsertInvitationData>();
            Invitation invitation=data.Invitation;
            this.datMgr.Invitation.Insert(invitation);
        }
    }
}
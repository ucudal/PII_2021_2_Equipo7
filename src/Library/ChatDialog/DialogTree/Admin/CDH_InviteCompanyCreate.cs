using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_InviteCompanyCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_InviteCompanyCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_InviteCompanyCreate(ChatDialogHandlerBase next) : base(next, "invite_company_create")
        {
            this.Parents.Add("invite_company_confirm");
            this.Route = "/confirmar";
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
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertInvitationData data = process.GetData<InsertInvitationData>();
            Invitation invitation=data.Invitation;
            this.DatMgr.Invitation.Insert(invitation);
        }
    }
}
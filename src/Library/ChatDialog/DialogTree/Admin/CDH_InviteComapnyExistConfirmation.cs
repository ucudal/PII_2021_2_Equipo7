using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_InviteComapnyExistConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_InviteComapnyExistConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_InviteComapnyExistConfirmation(ChatDialogHandlerBase next) : base(next, "invite_companyexist_confirm")
        {   this.Parents.Add("invite_company_exist_list");
            this.Route = null ;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertInvitationData data = new InsertInvitationData();
            data.Invitation.Type= RegistrationType.CompanyJoin;
            data.Invitation.CompanyId = int.Parse(selector.Code);
            DProcessData process = new DProcessData("companyexist_invite", this.Code, data);
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
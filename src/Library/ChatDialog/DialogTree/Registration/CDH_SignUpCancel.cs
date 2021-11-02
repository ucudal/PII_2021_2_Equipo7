using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso del comando de cancelar
    /// mientras se esta en uno de los pasos pertenecientes
    /// al proceso de registro de usuarios. Devuelve al
    /// usuario al menu de bienvenida.
    /// </summary>
    public class CDH_SignUpCancel : ChatDialogHandlerBase
    {
        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpCancel"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpCancel(ChatDialogHandlerBase next) : base(next, "registration_cancel")
        {
            this.parents.Add("registration_invite");
            this.parents.Add("registration_invite_comp_join");
            this.parents.Add("registration_invite_comp_new");
            this.parents.Add("registration_invite_entre_new");
            this.parents.Add("registration_invite_sysadmin_join");
            this.parents.Add("registration_user_f_name");
            this.parents.Add("registration_user_l_name");
            this.parents.Add("registration_new_comp_name");
            this.parents.Add("registration_new_comp_trade");
            this.parents.Add("registration_new_comp_verify");
            this.parents.Add("registration_new_sysadmin_verify");
            this.parents.Add("Sign_Review_Join_Company");
            this.parents.Add("registration_new_entre_name");
            this.parents.Add("registration_new_entre_trade");
            this.parents.Add("registration_join_sysadmin_verify");
            this.parents.Add("registration_new_entre_verify");

            this.route = "\\cancelar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = sessions.GetSession(selector.Service, selector.Account);
            session.MenuLocation = null;
            session.Process = null;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Ha cancelado el proceso de registro.\n");
            builder.Append("Gracias por visitar.");
            return builder.ToString();
        }
    }
}
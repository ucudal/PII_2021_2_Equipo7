using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al la verificacion de codigo de
    /// invitacion por el usuario. Comienza el proceso
    /// de ingreso de datos pidiendo en primer lugar
    /// el primer nombre del usuario.
    /// </summary>
    public class CDH_SignUpUserFirstName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpUserFirstName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpUserFirstName(ChatDialogHandlerBase next) : base(next, "registration_user_f_name")
        {
            this.parents.Add("registration_invite_comp_new");
            this.parents.Add("registration_invite_comp_join");
            this.parents.Add("registration_invite_entre_new");
            this.parents.Add("registration_invite_sysadmin_join");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Preciso algunos datos para registrarlo.\n");
            builder.Append("Ingrese su primer nombre:");
            return builder.ToString();
        }
    }
}
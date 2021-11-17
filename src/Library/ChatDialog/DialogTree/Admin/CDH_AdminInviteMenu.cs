using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_AdminInviteMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_AdminInviteMenu(ChatDialogHandlerBase next) : base(next, "invitemenu")
        {   this.parents.Add("welcome_sysadmin");
            this.route = "/invitar";


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcion invitar .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\admin : Invitacion de administradores del sistema.\n");
            builder.Append("\\emprendedor : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\compania_nueva : Invitacion de companias al sistema.\n");
            builder.Append("\\compania_existente \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }

    }
}
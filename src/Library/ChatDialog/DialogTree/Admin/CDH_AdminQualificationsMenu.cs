using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHAdminQualificationsMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminQualificationsMenu(ChatDialogHandlerBase next) : base(next, "hab_menu")
        {   this.parents.Add("welcome_sysadmin");
            this.route = "/habilitaciones";


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcionhabilitaciones .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\admin : Invitacion de administradores del sistema.\n");
            builder.Append("\\emprendedor : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\compania : Invitacion de companias al sistema.\n");
            builder.Append("\\cancelar \n");
            return builder.ToString();
        }

    }
}
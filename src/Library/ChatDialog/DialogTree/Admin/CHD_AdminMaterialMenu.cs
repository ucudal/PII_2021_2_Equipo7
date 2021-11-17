using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CHD_AdminMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CHD_AdminMaterialMenu(ChatDialogHandlerBase next) : base(next, "mat_menu")
        {   this.parents.Add("welcome_sysadmin");
            this.route = "/materiales";


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcion invitar .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\agregar : Invitacion de administradores del sistema.\n");
            builder.Append("\\listar : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\cancelar : Invitacion de companias al sistema.");
            return builder.ToString();
        }

    }
}
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDH_QualificationsAddNameMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_QualificationsAddNameMenu(ChatDialogHandlerBase next) : base(next, "hab_add_name")
        {   this.parents.Add("hab_menu");
            this.route = "\\agregar";


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre de la habilitacion\n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }

    }
}
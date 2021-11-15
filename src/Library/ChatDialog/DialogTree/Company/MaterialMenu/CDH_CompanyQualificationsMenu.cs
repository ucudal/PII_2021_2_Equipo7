using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationsMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationsMenu(ChatDialogHandlerBase next) : base(next, "company_qualifications_menu")
        {
            this.parents.Add("company_actions_material_menu");
            this.route = "/habilitaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu de habilitaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("/eliminar : Listar todas las habilitaciones del material que se pueden eliminar.\n");
            builder.Append("/agregar : Agregar una habilitacion al material.\n");
            builder.Append("/volver : Volver al menu de materiales .\n");
            return builder.ToString();
        }
    }
}
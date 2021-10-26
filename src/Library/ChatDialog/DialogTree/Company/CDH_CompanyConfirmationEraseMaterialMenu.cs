using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyConfirmationEraseMaterialMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyConfirmationEraseMaterialMenu(ChatDialogHandlerBase next) : base(next, "company_confirmation_erase_material_menu")
        {
            this.parents.Add("company_actions_material_menu");
            this.route = "\\eliminar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu confirmar eliminacion.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\confirmar : Confirmar que quiere eliminar el material.\n");
            builder.Append("\\cancelar : Cancelar operacion.\n");
            return builder.ToString();
        }
    }
}
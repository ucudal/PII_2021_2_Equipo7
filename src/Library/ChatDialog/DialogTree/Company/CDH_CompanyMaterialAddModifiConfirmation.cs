using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialAddModifiConfirmation : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialAddModifiConfirmation(ChatDialogHandlerBase next) : base(next, "company_material_add_modifi_confirmation_menu")
        {
            this.parents.Add("company_material_currency_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Confirmar ingreso/modificacion de material.\n");
            builder.Append("\\confirmar : Confirmar que quiere añadir el material.\n");
            builder.Append("\\cancelar : Cancelar operacion.\n");
            return builder.ToString();
        }
    }
}
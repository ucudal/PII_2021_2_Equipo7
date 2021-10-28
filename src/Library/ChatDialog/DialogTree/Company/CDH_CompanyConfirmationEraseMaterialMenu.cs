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
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            InsertCompanyMaterialData data = session.Process.GetData<InsertCompanyMaterialData>();
            

            StringBuilder builder = new StringBuilder();
            builder.Append("Menu confirmar eliminacion.\n");
            builder.Append($"El nombre del material es {data.CompanyMaterial.Name}");
            builder.Append("¿Seguro que desea eliminar el material?");
            builder.Append("\\confirmar : Confirmar que quiere eliminar el material.\n");
            builder.Append("\\cancelar : Cancelar operacion.\n");
            return builder.ToString();
        }
    }
}
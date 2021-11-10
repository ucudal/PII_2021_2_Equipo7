using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyModifiMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyModifiMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyModifiMenu(ChatDialogHandlerBase next) : base(next, "company_modifi_menu")
        {
            this.parents.Add("company_actions_material_menu");
            this.route = "/modificar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu para modificar un material.\n");
            builder.Append("Ingrese el numero de la categoria en la cual va el material.\n");
            builder.Append("En caso de querer cancelar la operacion escriba\n\n");
            builder.Append("\\cancelar : cancelar la operacion.\n");
            builder.Append(TextToPrintListCategories());
            return builder.ToString();
        }
        private string TextToPrintListCategories()
        {
            StringBuilder builder = new StringBuilder();
            foreach(MaterialCategory xCat in this.datMgr.MaterialCategory.Items)
            {
                builder.Append("" + xCat.Name + " " + xCat.Id + "");
            }
            return builder.ToString();
        }
    }
}
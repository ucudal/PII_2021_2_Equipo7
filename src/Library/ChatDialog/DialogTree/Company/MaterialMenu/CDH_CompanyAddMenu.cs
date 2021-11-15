using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyAddMenu(ChatDialogHandlerBase next) : base(next, "company_add_menu")
        {
            this.Parents.Add("company_material_menu");
            this.Route = "/ingresar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu para agregar un material.\n");
            builder.Append("Ingrese el numero de la categoria en la cual va el material.\n");
            builder.Append("En caso de querer cancelar la operacion escriba\n\n");
            builder.Append("\\cancelar : Listar todos los materiales que ya posee.\n");
            builder.Append(TextToPrintListCategories());
            return builder.ToString();
        }
        private string TextToPrintListCategories()
        {
            StringBuilder builder = new StringBuilder();
            foreach(MaterialCategory xCat in this.DatMgr.MaterialCategory.Items)
            {
                builder.Append("" + xCat.Name + " " + xCat.Id + "");
            }
            return builder.ToString();
        }
    }
}
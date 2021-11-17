using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_MaterialCategoryRemoveFromList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_MaterialCategoryRemoveFromList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_MaterialCategoryRemoveFromList(ChatDialogHandlerBase next) : base(next, "material_remove_from_list")
        {
            this.parents.Add("material_category_list");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertMaterialCategoryData data = new InsertMaterialCategoryData();
            data.MaterialCategory=this.datMgr.MaterialCategory.GetById(int.Parse(selector.Code));
            DProcessData process = new DProcessData("remove_category", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea eliminar la categoria del material.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
        
       
    }
}
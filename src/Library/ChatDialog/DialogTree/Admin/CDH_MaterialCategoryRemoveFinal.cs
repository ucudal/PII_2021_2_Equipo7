using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_MaterialCategoryRemoveFinal : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_MaterialCategoryRemoveFinal"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_MaterialCategoryRemoveFinal(ChatDialogHandlerBase next) : base(next, "matcat_remove_final")
        {
            this.parents.Add("material_remove_from_list");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if(EraseMatcat(selector))
            {
                builder.Append("Los datos se eliminaron correctamente.\n");
            }
            else
            {
                builder.Append("Los datos no se pudieron eliminar .\n");

            }
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        
        private bool EraseMatcat(ChatDialogSelector selector)
        {
            bool xretorno=false;
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertMaterialCategoryData data = process.GetData<InsertMaterialCategoryData>();
            MaterialCategory materialCategory = data.MaterialCategory;
            if(IsNotAllReadyToDelete(data)==false)
            {
                this.datMgr.MaterialCategory.Delete(materialCategory.Id);
                xretorno=true;
            }
            return xretorno;

        }
        private bool IsNotAllReadyToDelete(InsertMaterialCategoryData data)
        {
            bool xretorno=false;
            foreach(MaterialCategory xMatCat in this.datMgr.MaterialCategory.Items)
            {
                if(xMatCat.Id == data.MaterialCategory.Id)
                {
                    xretorno=true;
                }
            }
            
            return xretorno;
        }
    }
}
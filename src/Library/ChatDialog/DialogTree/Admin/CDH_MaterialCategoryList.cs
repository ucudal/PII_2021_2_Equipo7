using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_MaterialCategoryList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_MaterialCategoryList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_MaterialCategoryList(ChatDialogHandlerBase next) : base(next, "material_category_list")
        {
            this.Parents.Add("mat_menu");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Listado de Categoria De mMateriales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre alguna habilitaciom ingrese su numero.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(TextToPrintQualification(selector));
            builder.Append("LISTADO_CATMAT");
            return builder.ToString();
        }
        
        private string TextToPrintQualification(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            
            
            foreach( MaterialCategory materialCategory in this.DatMgr.MaterialCategory.Items)
            {
                
                xListMats.Append("" + materialCategory.Name +" " +materialCategory.Id + "\n");
            }
            return xListMats.ToString();
        }
    }
}
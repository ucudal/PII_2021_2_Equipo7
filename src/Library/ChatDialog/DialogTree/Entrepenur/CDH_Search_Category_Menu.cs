using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación por una categoria del material
    /// </summary>
    public class CDH_Search_Category_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_Category_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_Category_Menu(ChatDialogHandlerBase next) : base(next, "Search_Category_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "\\categoria";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar categoria \n");
            builder.Append(TextToPrintMaterialCategory());
            builder.Append("Ingrese el id de la categoria.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }

        private string TextToPrintMaterialCategory()
        {
            StringBuilder listCategory=new StringBuilder();
            foreach( MaterialCategory cate in this.DatMgr.MaterialCategory.Items)
            {
               listCategory.Append($" Identificador de la categoria - {cate.Id}\n");                
            }
            return listCategory.ToString();
        }


        
        
    }
}
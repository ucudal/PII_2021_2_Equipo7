using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación por una categoria del material
    /// </summary>
    public class CDHSearch_Category_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearch_Category_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearch_Category_Menu(ChatDialogHandlerBase next) : base(next, "Search_Category_Menu")
        {
            this.parents.Add("Search_Publication_Menu");
            this.route = "\\categoria";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar categoria \n");
            builder.Append(TextToPrintMaterialCategory());
            builder.Append("Ingrese el id de la categoria.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }

        private string TextToPrintMaterialCategory()
        {
            StringBuilder listCategory=new StringBuilder();
            foreach( MaterialCategory cate in this.datMgr.MaterialCategory.Items)
            {
               listCategory.Append($" Identificador de la categoria - {cate.Id}\n");                
            }
            return listCategory.ToString();
        }


        
        
    }
}
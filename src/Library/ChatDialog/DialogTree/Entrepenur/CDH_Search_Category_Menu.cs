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
            this.parents.Add("Search_Publication_Menu");
            this.route = "\\categoria";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar categoria \n");
            builder.Append(TextToPrintMaterialCategory(selector));
            builder.Append("Ingrese el id de la categoria.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }


        private string TextToPrintMaterialCategory(ChatDialogSelector selector)
        {
            StringBuilder listlocation=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            foreach( MaterialCategory cate in this.datMgr.MaterialCategory.Items)
            {
                if(cate.Id==int.Parse(selector.Code))
                {
                    MaterialCategory cate1=this.datMgr.MaterialCategory.GetById(cate.Id);
                    listlocation.Append($" Identificador de la categoria del material - {cate1.Id}\n");                
                }
            }
            return listlocation.ToString();
        }


        
        
    }
}
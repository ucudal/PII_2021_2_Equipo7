using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones.
    /// </summary>
    public class CDHList_KeyWords_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHList_KeyWords_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHList_KeyWords_Menu(ChatDialogHandlerBase next) : base(next, "List_KeyWords_Menu")
        {
            this.parents.Add("Search_KeyWord_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SearchPublication data = new SearchPublication();
            DProcessData process = new DProcessData("search_Publication_By_Location", this.code, data);

            builder.Append($"Listado de publicaciones con la palabra clave ingresada {selector.Code} \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por palabra clave .\n");
            builder.Append("LISTADO DE PUBLICACIONES: \n");
            builder.Append(TextToPrintPublication(selector));
            builder.Append("Ingrese el id de la publicación para ver detalles.\n");
            return builder.ToString();
        }
        
        private string TextToPrintPublication(ChatDialogSelector selector)
        {
            StringBuilder listpublicaciones=new StringBuilder();
            foreach(PublicationKeyWord keyWord in this.datMgr.PublicationKeyWord.Items)
            {
                if(keyWord.KeyWord==selector.Code)
                {
                    Publication publication=this.datMgr.Publication.GetById(keyWord.PublicationId);
                    CompanyMaterial mat=this.datMgr.CompanyMaterial.GetById(publication.CompanyMaterialId);
                    listpublicaciones.Append($" Identificador de la publicación - {publication.Id}, nombre del material - {mat.Name}\n");                
                }
            }
            return listpublicaciones.ToString();
        }
    }
}
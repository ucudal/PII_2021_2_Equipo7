using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones por localidad.
    /// </summary>
    public class CDH_List_Location_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_List_Location_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_List_Location_Menu(ChatDialogHandlerBase next) : base(next, "List_Location_Menu")
        {
            this.parents.Add("Search_Location_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append($"Listado de publicaciones con el id de localidad ingresada - {selector.Code} \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            builder.Append(TextToPrintPublicationMaterialLocation(selector));
            builder.Append("LISTADO DE PUBLICACIONES");
            builder.Append("Ingrese el id de la publicación para comprar.\n");
            return builder.ToString();
        }
        
        private string TextToPrintPublicationMaterialLocation(ChatDialogSelector selector)
        {
            StringBuilder listpublicaciones=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            foreach(Publication publi in this.datMgr.Publication.Items)
            {//ESTA MAL, LO DEBO COMPARAR CON LA LOCALIDAD DE LA PUBLICACION??
                if(publi.Id==int.Parse(selector.Code))
                {
                    Publication publication=this.datMgr.Publication.GetById(publi.Id);
                    CompanyMaterial mat=this.datMgr.CompanyMaterial.GetById(publication.CompanyMaterialId);
                    listpublicaciones.Append($" Identificador de la publicación - {publication.Id}, nombre del material - {mat.Name}\n");                
                }
            }
            return listpublicaciones.ToString();
        }
    }
}
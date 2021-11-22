using System.Text;
// ARREGLAR TODA LA CLASE
namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista compras hechas por el emprendedor.
    /// </summary>
    public class CDHHistory_Sale_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHHistory_Sale_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHHistory_Sale_Menu(ChatDialogHandlerBase next) : base(next, "History_Sale_Menu")
        {
            this.parents.Add("welcome_entrepreneur");
            this.route = "\\historialcompras";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append($"Listado de compras hechas \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            builder.Append(TextToPrintPublicationDetail(selector));
            builder.Append("LISTADO DE PUBLICACIONES");
            builder.Append("Ingrese el id de la publicación para comprar.\n");
            return builder.ToString();
        }
        //ARREGLAR EL TEXTTOPRINT
        private string TextToPrintPublicationDetail(ChatDialogSelector selector)
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
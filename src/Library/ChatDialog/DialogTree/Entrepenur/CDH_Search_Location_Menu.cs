using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una palabra clave
    /// </summary>
    public class CDH_Search_Location_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_Location_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_Location_Menu(ChatDialogHandlerBase next) : base(next, "Search_Location_Menu")
        {
            this.parents.Add("Search_Publication_Menu");
            this.route = "\\localidad";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar localidad \n");
            builder.Append(TextToPrintLocationCompany(selector));
            builder.Append("Ingrese el id de la localidad.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }


        private string TextToPrintLocationCompany(ChatDialogSelector selector)
        {
            StringBuilder listlocation=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            foreach( CompanyMaterialStock location in this.datMgr.CompanyMaterialStock.Items)
            {
               listlocation.Append($" Identificador de la location - {location.CompanyLocationId}\n");                
            }
            return listlocation.ToString();
        }     
    }
}
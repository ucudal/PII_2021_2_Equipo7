using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una palabra clave
    /// </summary>
    public class CDH_Search_KeyWord_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_KeyWord_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_KeyWord_Menu(ChatDialogHandlerBase next) : base(next, "Search_KeyWord_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "\\palabraclave";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar palabra clave \n");
            builder.Append("Ingrese su palabra clave.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }
        
        
    }
}
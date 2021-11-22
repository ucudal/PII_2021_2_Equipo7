using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una palabra clave
    /// </summary>
    public class CDHSearch_KeyWord_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSearch_KeyWord_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSearch_KeyWord_Menu(ChatDialogHandlerBase next) : base(next, "Search_KeyWord_Menu")
        {
            this.parents.Add("Search_Publication_Menu");
            this.route = "\\palabraclave";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Menu para ingresar palabra clave \n");
            builder.Append("Ingrese su palabra clave.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }
        
        
    }
}
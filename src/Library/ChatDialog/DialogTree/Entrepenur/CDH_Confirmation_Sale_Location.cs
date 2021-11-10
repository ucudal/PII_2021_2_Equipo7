using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la confirmación de la ´publicación.
    /// </summary>
    public class CDH_Confirmation_Sale_Location : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Confirmation_Sale_Location"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Confirmation_Sale_Location(ChatDialogHandlerBase next) : base(next, "Confirmation_Sale_Location")
        {
            this.parents.Add("Sale_Publication_Location");
            this.route = "\\comprar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append($"Quieres confirmar la compra de una publicación de Id - {selector.Code} \n");
            builder.Append("\\confirmar : Confirma la compra la publicación\n");
            builder.Append("\\cancelar : Cancelar la compra\n");
            return builder.ToString();
        }
    }
}
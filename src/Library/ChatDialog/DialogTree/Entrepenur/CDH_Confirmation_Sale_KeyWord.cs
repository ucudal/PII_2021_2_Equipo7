using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la confirmación de la ´publicación.
    /// </summary>
    public class CDH_Confirmation_Sale_KeyWord : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Confirmation_Sale_KeyWord"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Confirmation_Sale_KeyWord(ChatDialogHandlerBase next) : base(next, "Confirmation_Sale_KeyWord")
        {
            this.Parents.Add("Sale_Publication_KeyWord");
            this.Route = "\\comprar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process=session.Process;
            SearchPublication data=process.GetData<SearchPublication>();
            
            builder.Append($"Quieres confirmar la compra de una publicación de Id - {data.Publication.Id} \n");
            builder.Append("\\confirmar : Confirma la compra la publicación\n");
            builder.Append("\\cancelar : Cancelar la compra\n");
            return builder.ToString();
        }
    }
}
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la compra de la ´publicación.
    /// </summary>
    public class CDH_Sale_Publication_KeyWord : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Sale_Publication_KeyWord"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Sale_Publication_KeyWord(ChatDialogHandlerBase next) : base(next, "Sale_Publication_KeyWord")
        {
            this.parents.Add("List_KeyWords_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process=session.Process;
            InsertPublicationData data=process.GetData<InsertPublicationData>();
            data.Publication=this.datMgr.Publication.GetById(int.Parse(selector.Code));
            
            builder.Append($"Quieres comprar la publicación de Id - {selector.Code} \n");
            builder.Append("\\comprar : Compra la publicación\n");
            builder.Append("\\cancelar : Cancela la compra\n");
            return builder.ToString();
        }
    }
}
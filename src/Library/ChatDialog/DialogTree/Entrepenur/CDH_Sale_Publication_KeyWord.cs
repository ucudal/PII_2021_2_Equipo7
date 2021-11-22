using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la compra de la ´publicación.
    /// </summary>
    public class CDHSale_Publication_KeyWord : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHSale_Publication_KeyWord"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSale_Publication_KeyWord(ChatDialogHandlerBase next) : base(next, "Sale_Publication_KeyWord")
        {
            this.parents.Add("List_KeyWords_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            SearchPublication data=new SearchPublication();
            DProcessData process = new DProcessData("search_Publication_By_KeyWord", this.code, data);
            data.Publication=this.datMgr.Publication.GetById(int.Parse(selector.Code));
            
            builder.Append($"Datos de la publicacion con Id - {data.Publication.Id} \n");
            builder.Append($"Material - {this.datMgr.CompanyMaterial.GetById(data.Publication.CompanyMaterialId).Name} \n");
            builder.Append($"Cantidad - {data.Publication.Quantity} \n");
            builder.Append($"Precio - {data.Publication.Price} \n");
            builder.Append($"Lugar - {this.datMgr.CompanyLocation.GetById(data.Location.Id).GeoReference} \n");
            builder.Append($"Fecha de publicacion - {data.Publication.ActiveFrom.ToString()} \n");
            builder.Append($"Se pueden realizar las siguientes operaciones sobre esta publicacion \n");
            builder.Append("\\comprar : Compra la publicación\n");
            builder.Append("\\cancelar : Cancela la compra\n");
            return builder.ToString();
        }
    }
}
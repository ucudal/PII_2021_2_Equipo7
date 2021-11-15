using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la compra de la ´publicación.
    /// </summary>
    public class CDH_Sale_Publication_Category : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Sale_Publication_Category"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Sale_Publication_Category(ChatDialogHandlerBase next) : base(next, "Sale_Publication_Category")
        {
            this.parents.Add("List_Category_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process=session.Process;
            SearchPublication data=process.GetData<SearchPublication>();
            data.Publication=this.datMgr.Publication.GetById(int.Parse(selector.Code));
            
            builder.Append($"Datos de la publicacion con Id - {data.Publication.Id} \n");
            builder.Append($"Material - {this.datMgr.CompanyMaterial.GetById(data.Publication.CompanyMaterialId).Name} \n");
            builder.Append($"Cantidad - {data.Publication.Quantity} \n");
            builder.Append($"Precio - {data.Publication.Price} \n");
            builder.Append($"Lugar - {this.datMgr.CompanyLocation.GetById(data.Location.Id).GeoReference} \n");
            builder.Append($"Fecha de publicacion - {data.Publication.ActiveFrom.ToString()} \n");
            builder.Append($"Se pueden realizar las siguientes operaciones sobre esta publicacion \n");
            builder.Append("/comprar : Compra la publicación\n");
            builder.Append("/cancelar : Cancela la compra\n");
            return builder.ToString();
        }
    }
}
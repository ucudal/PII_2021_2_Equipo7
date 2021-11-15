using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista compras hechas por el emprendedor.
    /// </summary>
    public class CDH_History_Sale_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_History_Sale_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_History_Sale_Menu(ChatDialogHandlerBase next) : base(next, "History_Sale_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "\\historialcompras";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
           
            builder.Append($"Listado de compras hechas \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            builder.Append(TextAllPublicationsBougth(selector));
            builder.Append("LISTADO DE Compras");
            builder.Append("Ingrese el id de la compra para ver mas detalles.\n");
            return builder.ToString();
        }
        private string TextAllPublicationsBougth(ChatDialogSelector selector)
        {
            StringBuilder listaCompras=new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            foreach(Sale xSale in this.DatMgr.Sale.Items)
            {
                if(xSale.BuyerEntrepreneurId==session.UserId)
                {
                    
                    listaCompras.Append($" Identificador de la compra - {xSale.Id}, nombre del material - {this.DatMgr.CompanyMaterial.GetById(xSale.ProductCompanyMaterialId).Name}\n");                
                }
                
            }
            return listaCompras.ToString();
        }
    }
}
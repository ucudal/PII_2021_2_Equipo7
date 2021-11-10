using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la transacción de la compra.
    /// </summary>
    public class CDH_Final_Sale_Location : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Final_Sale_Location"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Final_Sale_Location(ChatDialogHandlerBase next) : base(next, "Final_Sale_Location")
        {
            this.parents.Add("Confirmation_Sale_Location");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process=session.Process;
            InsertPublicationData data=process.GetData<InsertPublicationData>();
            
            Sale compra=this.datMgr.Sale.New();
            compra.Price=data.Publication.Price;
            compra.ProductCompanyMaterialId=data.Publication.CompanyMaterialId;
            compra.ProductQuantity=data.Publication.Quantity;
            compra.SellerCompanyId=data.Publication.CompanyId;
            compra.DateTime=System.DateTime.Now;
            compra.BuyerEntrepreneurId=session.UserId;
            compra.Currency=data.Publication.Currency;


            this.datMgr.Sale.Insert(compra);

            builder.Append("Compra realizada exitosamente \n");
            builder.Append("\\volver : Volver al menu principal.\n");
            return builder.ToString();
        }


    }
}
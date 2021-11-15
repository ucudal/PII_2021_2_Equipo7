using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationPriceMaterialToAddMenu : ChatDialogHandlerBase
    {
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationPriceMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationPriceMaterialToAddMenu(ChatDialogHandlerBase next) : base(next, "company_publication_price_material_to_add_menu")
        {
            this.parents.Add("company_publication_quantity_material_to_add_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.Publication.Quantity=int.Parse(selector.Code);
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el precio que le quiere poner a la publicacion.\n");
            builder.Append("/cancelar : En caso de querer canclear la operacion.\n");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            bool xretorno=false;
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
    
                    xretorno=true;

                }
            }
            return xretorno;
        }
    }
}
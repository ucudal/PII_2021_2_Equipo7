using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationConfirmationAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationConfirmationAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationConfirmationAddMenu(ChatDialogHandlerBase next) : base(next, "company_publication_confirmation_add_menu")
        {
            this.Parents.Add("company_publication_price_material_to_add_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();

            data.Publication.Price=int.Parse(selector.Code);

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");
            builder.Append("Nombre: " + data.CompanyMaterial.Name);
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            bool xretorno=false;
            if (this.Parents.Contains(selector.Context))
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
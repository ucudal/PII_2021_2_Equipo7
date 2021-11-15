using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationEraseDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationEraseDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationEraseDataMenu(ChatDialogHandlerBase next) : base(next, "company_publication_erase_data_menu")
        {
            this.parents.Add("company_publication_confirmation_erase_menu");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            PublicationEraseData(selector);
            builder.Append("La publicacion se elimino con exito.\n");
            builder.Append("Escriba ");
            builder.Append("/cancelar : para volver al menu de materiales .\n");
            return builder.ToString();
        }
        private void PublicationEraseData(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            this.datMgr.Publication.Delete(data.Publication.Id);
        }
    }
}
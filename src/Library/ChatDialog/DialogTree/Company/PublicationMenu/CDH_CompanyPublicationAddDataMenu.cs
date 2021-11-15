using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationAddDataMenu(ChatDialogHandlerBase next) : base(next, "company_publication_add_data_menu")
        {
            this.parents.Add("company_publication_confirmation_add_menu");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            //PublicationAdd(selector);
            builder.Append("La publicacion se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("/volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }
        /*
        private void PublicationAdd(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.PublicationItem.CompanyMaterial=data.CompanyMaterial;
            Publication xPubl=data.Publication;
            xPubl.PublicationItem=data.PublicationItem;
            xPubl.Company=this.companyAdmin.Items.Find(obj => obj.ListAdminUsers.Exists(admin => admin.Id==session.UserId));
            publicationAdmin.Insert(xPubl);
        }*/
    }
}
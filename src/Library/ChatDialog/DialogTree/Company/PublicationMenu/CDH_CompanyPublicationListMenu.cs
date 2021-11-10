using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationListMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationListMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationListMenu(ChatDialogHandlerBase next) : base(next, "company_publication_list_menu")
        {
            this.parents.Add("company_publication_menu");
            this.route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de publicaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la publicacion con la cual quiere trabajar \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            //builder.Append(TextoToPrintQualificationsToErase(selector));
            builder.Append("LISTADO_PUBLICACIONES");
            return builder.ToString();
        }
        /*
        private string TextoToPrintQualificationsToErase(ChatDialogSelector selector)
        {            
             StringBuilder builder = new StringBuilder();
            foreach(Publication xPub in publicationAdmin.Items)
            {
                builder.Append("" + xPub.Id + " "+  xPub.PublicationItem.CompanyMaterial.Name + " " + xPub.Price + "\n");
            }
            return builder.ToString();
        }*/
    }
}
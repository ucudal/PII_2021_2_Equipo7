using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationActionMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationActionMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationActionMenu(ChatDialogHandlerBase next) : base(next, "company_publication_action_menu")
        {
            this.Parents.Add("company_publication_list_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertPublicationData data = new InsertPublicationData();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = new UserActivity("select_publication", null, this.Code,data);
            data.Publication=this.DatMgr.Publication.GetById(int.Parse(selector.Code));
    
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu acciones sobre la publicacion elegido.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\modificar : Modificar la publicacion.\n");
            builder.Append("\\eliminar : Eliminar la publicacion.\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    Publication publication = this.DatMgr.Publication.GetById(int.Parse(selector.Code));
                    if (publication is not null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
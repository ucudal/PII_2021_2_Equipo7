using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationListMaterialsToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationListMaterialsToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationListMaterialsToAddMenu(ChatDialogHandlerBase next) : base(next, "company_publication_list_material_to_add_menu")
        {
            this.parents.Add("company_publication_menu");
            this.route = "/ingresar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();            
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("Ingrese el numero del material que quiere añadir a la publicacion.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            //builder.Append(TextToPrintCompanyMaterial(selector));
            builder.Append("LISTADO_MATERIALES");
            return builder.ToString();
        }
        /*
        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            Company company = this.companyAdmin.Items.Find(obj => obj.ListAdminUsers.Exists(admin => admin.Id==session.UserId));
            foreach(CompanyMaterial xMat in company.CompanyMaterials)
            {
                xListMats.Append("" + xMat.Name +" " +xMat.Id + "\n");
            }
            return xListMats.ToString();
        }*/
    }
}
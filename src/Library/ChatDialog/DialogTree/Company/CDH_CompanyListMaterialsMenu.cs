using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyListMaterialsMenu : ChatDialogHandlerBase
    {
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;
        private CompanyMaterialAdmin companyMaterialAdmin=Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyListMaterialsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyListMaterialsMenu(ChatDialogHandlerBase next) : base(next, "company_list_material_menu")
        {
            this.parents.Add("company_material_menu");
            this.route = "\\listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre algun material ingrese su numero.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            //builder.Append("\\siguiente : Siguiente pagina de materiales.\n");
            //builder.Append("\\anterior: Pagina anterior de materiales.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(TextToPrintCompanyMaterial(selector));
            return builder.ToString();
        }

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
        }
    }
}
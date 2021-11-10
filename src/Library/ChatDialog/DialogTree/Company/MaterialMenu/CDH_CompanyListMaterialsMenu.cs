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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyListMaterialsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyListMaterialsMenu(ChatDialogHandlerBase next) : base(next, "company_list_material_menu")
        {
            this.parents.Add("company_material_menu");
            this.route = "/listar";
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
            builder.Append("\\siguiente : Siguiente pagina de materiales.\n");
            builder.Append("\\anterior: Pagina anterior de materiales.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(TextToPrintCompanyMaterial(selector));
            builder.Append("LISTADO_MATERIALES");
            return builder.ToString();
        }
        
        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            
            Company company = this.datMgr.Company.GetById(this.datMgr.CompanyUser.GetCompanyForUser(session.UserId));
            foreach(int xIdCompanyMaterial in this.datMgr.CompanyMaterial.GetCompanyMaterialsInCompany(company.Id))
            {
                CompanyMaterial xMat=this.datMgr.CompanyMaterial.GetById(xIdCompanyMaterial);
                xListMats.Append("" + xMat.Name +" " +xMat.Id + "\n");
            }
            return xListMats.ToString();
        }
    }
}
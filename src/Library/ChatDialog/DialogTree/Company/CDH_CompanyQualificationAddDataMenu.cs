using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationAddDataMenu : ChatDialogHandlerBase
    {
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationAddDataMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_add_data_menu")
        {
            this.parents.Add("company_qualification_add_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            AddQualificationToMaterial(selector);
            builder.Append("Habilitacion agregada con exito.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void AddQualificationToMaterial(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = new DProcessData("select_companymaterial",this.code,null);
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.CompanyMaterial.AddQualification(data.Qualification);
            Company company=this.companyAdmin.Items.Find(obj => obj.ListAdminUsers.Exists(admin => admin.Id==session.UserId));
            companyAdmin.Update(company);
            CompanyMaterial companyMaterial=this.companyMaterialAdmin.Items.Find(obj => obj.Id==session.UserId);
            companyMaterialAdmin.Update(companyMaterial);
        }
    }
}
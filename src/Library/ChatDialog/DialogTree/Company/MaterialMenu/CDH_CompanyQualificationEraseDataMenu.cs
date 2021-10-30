using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationEraseDataMenu : ChatDialogHandlerBase
    {
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationEraseDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationEraseDataMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_erase_data_menu")
        {
            this.parents.Add("company_qualification_confirm_to_erase_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            QualificationEraseData(selector);
            builder.Append("La habilitacion se elimino con exito.\n");
            builder.Append("Escriba ");
            builder.Append("\\cancelar : para volver al menu de materiales .\n");
            return builder.ToString();
        }
        private void QualificationEraseData(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = new DProcessData("select_companymaterial",this.code,null);
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.CompanyMaterial.Qualifications.Remove(data.Qualification);
            Company company=this.companyAdmin.Items.Find(obj => obj.ListAdminUsers.Exists(admin => admin.Id==session.UserId));
            companyAdmin.Update(company);
            CompanyMaterial companyMaterial=this.companyMaterialAdmin.Items.Find(obj => obj.Id==session.UserId);
            companyMaterialAdmin.Update(companyMaterial);
        }
    }
}
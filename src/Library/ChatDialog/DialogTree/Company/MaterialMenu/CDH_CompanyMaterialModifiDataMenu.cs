using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyMaterialModifiDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiDataMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_data_menu")
        {
            this.parents.Add("company_material_modifi_confirmation_menu");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            MaterialModifi(selector);
            builder.Append("El material se modifico satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void MaterialModifi(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();

            CompanyMaterial companyMaterial=data.CompanyMaterial;
            Company company=this.datMgr.Company.GetById(this.datMgr.CompanyUser.GetCompanyForUser(session.UserId));
            if(company!=null)
            {
                companyMaterial.CompanyId=company.Id;
            }
            this.datMgr.CompanyLocation.Update(this.datMgr.CompanyLocation.GetById(data.CompanyMaterialStock.CompanyLocationId));
            this.datMgr.CompanyMaterialStock.Update(data.CompanyMaterialStock);
            this.datMgr.CompanyMaterial.Update(companyMaterial);
            this.datMgr.Company.Update(company);
        }
    }
}
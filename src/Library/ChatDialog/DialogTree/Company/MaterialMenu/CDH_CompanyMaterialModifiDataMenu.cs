using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiDataMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_data_menu")
        {
            this.Parents.Add("company_material_modifi_confirmation_menu");
            this.Route = "/confirmar";
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
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();

            CompanyMaterial companyMaterial=data.CompanyMaterial;
            Company company=this.DatMgr.Company.GetById(this.DatMgr.CompanyUser.GetCompanyForUser(session.UserId));
            if(company!=null)
            {
                companyMaterial.CompanyId=company.Id;
            }
            this.DatMgr.CompanyLocation.Update(this.DatMgr.CompanyLocation.GetById(data.CompanyMaterialStock.CompanyLocationId));
            this.DatMgr.CompanyMaterialStock.Update(data.CompanyMaterialStock);
            this.DatMgr.CompanyMaterial.Update(companyMaterial);
            this.DatMgr.Company.Update(company);
        }
    }
}
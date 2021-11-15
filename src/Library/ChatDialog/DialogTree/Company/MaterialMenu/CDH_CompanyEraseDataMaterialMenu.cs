using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyEraseDataMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyEraseDataMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyEraseDataMaterialMenu(ChatDialogHandlerBase next) : base(next, "company_erase_data_material_menu")
        {
            this.parents.Add("company_confirmation_erase_material_menu");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            EraseMaterialFromCompany(selector);
            builder.Append("Los datos se eliminaron correctamente.\n");
            builder.Append("escriba \n");
            builder.Append("/volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void EraseMaterialFromCompany(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            CompanyMaterial xMat=this.datMgr.CompanyMaterial.GetById(data.CompanyMaterial.Id);
            xMat.Deleted=true;
            this.datMgr.CompanyMaterial.Update(xMat);
        }
    }
}
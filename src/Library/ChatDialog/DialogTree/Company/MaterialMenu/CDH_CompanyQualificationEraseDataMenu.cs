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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationEraseDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationEraseDataMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_erase_data_menu")
        {
            this.parents.Add("company_qualification_confirm_to_erase_menu");
            this.route = "/confirmar";
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
            DProcessData process = session.Process;
            SelectCompanyMaterialQualificationData data = process.GetData<SelectCompanyMaterialQualificationData>();
            CompanyMaterialQualification xHabiMat=this.datMgr.CompanyMaterialQualification.GetById(data.CompanyMaterialQualification.Id);
            xHabiMat.Deleted=true;
            this.datMgr.CompanyMaterialQualification.Update(xHabiMat);            
        }
    }
}
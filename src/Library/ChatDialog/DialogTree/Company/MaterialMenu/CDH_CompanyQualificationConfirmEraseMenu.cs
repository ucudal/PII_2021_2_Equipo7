using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationConfirmEraseMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationConfirmEraseMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationConfirmEraseMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_confirm_to_erase_menu")
        {
            this.parents.Add("company_qualifications_list_to_erase_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialQualificationData data = process.GetData<SelectCompanyMaterialQualificationData>();
            data.CompanyMaterialQualification=this.datMgr.CompanyMaterialQualification.GetById(int.Parse(selector.Code));

            builder.Append("Esta seguro que desea eliminar la habilitacion con el nombre " + this.datMgr.CompanyMaterial.GetById(data.CompanyMaterialQualification.CompanyMatId).Name + " ?\n ");
            builder.Append("Esta seguro que desea eliminar la habilitacion con el nombre ?\n");
            builder.Append("\\confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    Qualification qualification = this.datMgr.Qualification.GetById(int.Parse(selector.Code));
                    if (qualification is not null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
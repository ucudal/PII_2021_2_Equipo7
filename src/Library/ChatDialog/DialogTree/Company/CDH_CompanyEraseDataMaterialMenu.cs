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
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyEraseDataMaterialMenu(ChatDialogHandlerBase next) : base(next, "company_erase_data_material_menu")
        {
            this.parents.Add("company_confirmation_elimination_material_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            EraseMaterialFromCompany(selector);
            builder.Append("Los datos se eliminaron correctamente.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        private void EraseMaterialFromCompany(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            NECESITO LA COMPAÑIA QUE ESTA LOGUEADA
            Company company = this.companyAdmin.GetById(session.UserId);
            company.CompanyMaterials.RemoveAll(obj=>obj.Id==IDMATERIAL)
        }
    }
}
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialAddConfirmationMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialAddConfirmationMenu(ChatDialogHandlerBase next) : base(next, "company_material_add_confirmation_menu")
        {
            this.parents.Add("company_material_name_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();

            CompanyMaterial companyMaterial = this.companyMatAdmin.New();
            companyMaterial.Name = selector.Code.Trim();
            data.CompanyMaterial = companyMaterial;

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");
            builder.Append("Nombre: " + data.CompanyMaterial.Name);
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            return builder.ToString();
        }
    }
}
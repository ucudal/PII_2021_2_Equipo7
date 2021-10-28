using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyActionsMaterialMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyActionsMaterialMenu(ChatDialogHandlerBase next) : base(next, "company_actions_material_menu")
        {
            this.parents.Add("company_list_material_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();

            CompanyMaterial mat=this.companyMaterialAdmin.GetById(int.Parse(selector.Code));
            data.CompanyMaterial=mat;

            StringBuilder builder = new StringBuilder();
            builder.Append("Menu acciones sobre el material elegido.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\modificar : Modificar el material.\n");
            builder.Append("\\eliminar : Eliminar el material.\n");
            builder.Append("\\habilitaciones : Acceder a menu de habilitaciones.\n");
            return builder.ToString();
        }
    }
}
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
            SelectCompanyMaterialData data = new SelectCompanyMaterialData();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = new DProcessData("select_companymaterial",this.code,data);
            //data.CompanyMaterial=companyMaterialAdmin.Items.Find(obj => obj.Id==int.Parse(selector.Code));
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu acciones sobre el material elegido.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\modificar : Modificar el material.\n");
            builder.Append("\\eliminar : Eliminar el material.\n");
            builder.Append("\\habilitaciones : Acceder a menu de habilitaciones.\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    CompanyMaterial companyMaterial = companyMaterialAdmin.GetById(int.Parse(selector.Code));
                    if (companyMaterial is not null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
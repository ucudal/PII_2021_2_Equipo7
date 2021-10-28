using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiDateBetweenReStockMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiDateBetweenReStockMenu(ChatDialogHandlerBase next) : base(next, "company_material_name_menu")
        {
            this.parents.Add("company_add_modifi_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            DProcessData process = new DProcessData("add_Material", this.code, null);

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();
            data.Stock.Location.Georeference=selector.Code;
                
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la ubicacion del material.\n");
            builder.Append("\\cancelar : Listar todos los materiales que ya posee.\n");
            return builder.ToString();
        }
    }
}
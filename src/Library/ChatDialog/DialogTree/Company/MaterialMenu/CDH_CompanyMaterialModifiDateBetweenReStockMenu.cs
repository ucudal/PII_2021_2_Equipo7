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
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiDateBetweenReStockMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiDateBetweenReStockMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_dateBetweenReStock_menu")
        {
            this.parents.Add("company_material_modifi_ubication_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            DProcessData process = new DProcessData("modifi_Material", this.code, null);

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.Stock.Location.Georeference=selector.Code;
                
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la ubicacion del material.\n");
            builder.Append("\\cancelar : Listar todos los materiales que ya posee.\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
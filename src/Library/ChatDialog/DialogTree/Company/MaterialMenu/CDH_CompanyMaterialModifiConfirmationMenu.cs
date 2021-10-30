using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiConfirmationMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiConfirmationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiConfirmationMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_confirmation_menu")
        {
            this.parents.Add("company_material_modifi_dateBetweenReStock_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();

            data.CompanyMaterial.DateBetweenRestocks=int.Parse(selector.Code);
            data.CompanyMaterial.StockPerLocations.Add(data.Stock);

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");
            builder.Append("Nombre: " + data.CompanyMaterial.Name + "\n");
            builder.Append("Categoria: " + data.MaterialCategory.Name + "\n");
            builder.Append("Cantidad: " + data.Stock.Stock + "\n");
            builder.Append("Ubicacion: " +  data.Stock.Location + "\n");
            builder.Append("Re-Establecimiento de stock cada: " +  data.CompanyMaterial.DateBetweenRestocks + "\n");
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("\\cancelar : En caso de querer cancelar la operacion.\n");
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
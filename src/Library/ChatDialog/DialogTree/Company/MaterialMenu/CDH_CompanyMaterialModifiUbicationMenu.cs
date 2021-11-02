using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiUbicationMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiUbicationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiUbicationMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_ubication_menu")
        {
            this.parents.Add("company_material_modifi_quantity_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;;
            session.Process = process;
            //SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            //data.Stock.Stock=int.Parse(selector.Code);
            

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
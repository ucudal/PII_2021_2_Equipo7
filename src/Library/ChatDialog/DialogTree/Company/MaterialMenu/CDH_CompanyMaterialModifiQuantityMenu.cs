using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiQuantityMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiQuantityMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiQuantityMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_quantity_menu")
        {
            this.Parents.Add("company_material_modifi_name_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;;
            session.CurrentActivity = process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            CompanyMaterial companyMaterial = this.DatMgr.CompanyMaterial.New();
            companyMaterial.Name = selector.Code.Trim();
            data.CompanyMaterial = companyMaterial;
            

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la cantidad del material.\n");
            builder.Append("\\cancelar : Listar todos los materiales que ya posee.\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
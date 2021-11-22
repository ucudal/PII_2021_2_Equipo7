using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyMaterialModifiQuantityMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiQuantityMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiQuantityMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_quantity_menu")
        {
            this.parents.Add("company_material_modifi_name_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;;
            session.Process = process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
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
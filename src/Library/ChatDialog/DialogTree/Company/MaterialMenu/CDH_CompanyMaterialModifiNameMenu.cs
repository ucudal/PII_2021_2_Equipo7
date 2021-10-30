using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialModifiNameMenu : ChatDialogHandlerBase
    {
        private MaterialCategoryAdmin matCatAdmin = Singleton<MaterialCategoryAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialModifiNameMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialModifiNameMenu(ChatDialogHandlerBase next) : base(next, "company_material_modifi_name_menu")
        {
            this.parents.Add("company_modifi_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            DProcessData process = new DProcessData("modifi_material", this.code, null);

            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            MaterialCategory matCat = matCatAdmin.GetById(int.Parse(selector.Code));
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.MaterialCategory=matCat;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre del material.\n");
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
                    //Falta pasar de string a int el code
                    MaterialCategory matCat = matCatAdmin.GetById(int.Parse(selector.Code));
                    if (matCat is not null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
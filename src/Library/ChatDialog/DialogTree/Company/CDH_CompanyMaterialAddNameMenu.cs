using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialAddNameMenu : ChatDialogHandlerBase
    {
        private MaterialCategoryAdmin matCatAdmin = Singleton<MaterialCategoryAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialAddNameMenu(ChatDialogHandlerBase next) : base(next, "company_material_name_menu")
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
            MaterialCategory matCat = matCatAdmin.GetById(int.Parse(selector.Code));
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();
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
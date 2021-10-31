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
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialAddNameMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialAddNameMenu(ChatDialogHandlerBase next) : base(next, "company_material_add_name_menu")
        {
            this.parents.Add("company_add_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            MaterialCategory matCat = matCatAdmin.GetById(int.Parse(selector.Code));
            InsertCompanyMaterialData data = new InsertCompanyMaterialData();
            data.MaterialCategory=matCat;
            DProcessData process = new DProcessData("add_Material", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            


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
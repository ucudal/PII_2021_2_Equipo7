using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyPublicationQuantityMaterialToAddMenu : ChatDialogHandlerBase
    {
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationQuantityMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationQuantityMaterialToAddMenu(ChatDialogHandlerBase next) : base(next, "company_publication_quantity_material_to_add_menu")
        {
            this.parents.Add("company_publication_list_material_to_add_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
        
            CompanyMaterial xMat=companyMaterialAdmin.GetById(int.Parse(selector.Code));
            InsertPublicationData data = new InsertPublicationData();
            data.CompanyMaterial=xMat;
            DProcessData process = new DProcessData("add_material_to_publication", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;


            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la cantidad del material que quiere agregar a la publicacion.\n");
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
                    CompanyMaterial xMat = companyMaterialAdmin.GetById(int.Parse(selector.Code));
                    if (xMat is not null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
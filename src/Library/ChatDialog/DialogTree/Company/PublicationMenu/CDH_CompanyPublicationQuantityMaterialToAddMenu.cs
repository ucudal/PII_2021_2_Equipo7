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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyPublicationQuantityMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyPublicationQuantityMaterialToAddMenu(ChatDialogHandlerBase next) : base(next, "company_publication_quantity_material_to_add_menu")
        {
            this.Parents.Add("company_publication_list_material_to_add_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertPublicationData data = new InsertPublicationData();
            CompanyMaterial xMat=this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code));            
            data.Publication.CompanyMaterialId=xMat.CompanyId;
            UserActivity process = new UserActivity("add_material_to_publication", null, this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;
            data.Publication.CompanyId=this.DatMgr.CompanyUser.GetCompanyForUser(session.UserId);

            


            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la cantidad del material que quiere agregar a la publicacion.\n");
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
                    CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code));
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
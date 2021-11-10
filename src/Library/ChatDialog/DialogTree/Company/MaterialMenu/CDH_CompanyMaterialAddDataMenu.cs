using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyMaterialAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyMaterialAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyMaterialAddDataMenu(ChatDialogHandlerBase next) : base(next, "company_material_add_data_menu")
        {
            this.parents.Add("company_material_add_confirmation_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            MaterialAdd(selector);
            builder.Append("El material se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void MaterialAdd(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertCompanyMaterialData data = process.GetData<InsertCompanyMaterialData>();
            CompanyMaterial companyMaterial=data.CompanyMaterial;
            this.datMgr.CompanyMaterial.Insert(companyMaterial);
        }
    }
}
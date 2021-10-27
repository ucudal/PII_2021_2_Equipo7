using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class CDH_Company_Tracing_Menu : ChatDialogHandlerBase
    {
        
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Company_Tracing_Menu(ChatDialogHandlerBase next) : base(next, "company_Tracing_menu")
        {
            this.parents.Add("welcome_company");
            this.route = "\\listar";
        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Listado de materiales existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre algun material ingrese su numero.\n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            //builder.Append("\\siguiente : Siguiente pagina de materiales.\n");
            //builder.Append("\\anterior: Pagina anterior de materiales.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(TextToPrintCompanyMaterial(selector));
            return builder.ToString();
        }

    }

}
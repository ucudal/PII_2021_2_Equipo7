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

    }

}
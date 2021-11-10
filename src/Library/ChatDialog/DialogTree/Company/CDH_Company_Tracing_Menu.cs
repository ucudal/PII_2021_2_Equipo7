using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class CDH_Company_Tracing_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Company_Tracing_Menu(ChatDialogHandlerBase next) : base(next, "company_Tracing_menu")
        {
            this.parents.Add("welcome_company");
            this.route = "/listar";
        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Seguimiento de materiales \n");
            builder.Append("Cantidad vendida por material\n");
            //builder.Append("\\siguiente : Siguiente pagina de materiales.\n");
            //builder.Append("\\anterior: Pagina anterior de materiales.\n");
            builder.Append("\\cancelar : Volver a menu de empresas .\n");
            //builder.Append(TextToPrintCompanyMaterial(selector));
            return builder.ToString();
        }

        /*
        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            Company company = this.datMgr.Company.FindAdminUser(session.UserId);
            List<Sale> sales = this.datMgr.User.GetByCompanyId(company.Id);
            Dictionary<int,int> saleByMatirial = new Dictionary<int,int>();
        
            foreach(Sale sale in sales)
            {
                if(saleByMatirial.ContainsKey(sale.PublicationItem.CompanyMaterial.Id))
                {
                    saleByMatirial[sale.PublicationItem.CompanyMaterial.Id] += sale.PublicationItem.Quantity;
                }
                else
                {
                    saleByMatirial[sale.PublicationItem.CompanyMaterial.Id] = sale.PublicationItem.Quantity;
                }
            }
            foreach(int key in saleByMatirial.Keys)
            {
                xListMats.Append($"El material {key} se vendió una cantidad de {saleByMatirial[key]}\n");
            }
            return xListMats.ToString();
        }
        */
    }
}
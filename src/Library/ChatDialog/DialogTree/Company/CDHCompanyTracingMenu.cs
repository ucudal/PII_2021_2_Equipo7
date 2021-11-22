// -----------------------------------------------------------------------
// <copyright file="CDH_Company_Tracing_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para el seguimiento del material.
    /// </summary>
    public class CDHCompanyTracingMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyTracingMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyTracingMenu(ChatDialogHandlerBase next)
        : base(next, "company_Tracing_menu")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Seguimiento de materiales \n");
            builder.Append("Cantidad vendida por material\n");
            builder.Append("\\cancelar : Volver a menu de empresas .\n");
            return builder.ToString();
        }

        /*
        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            Company company = this.DatMgr.Company.FindAdminUser(session.UserId);
            List<Sale> sales = this.DatMgr.User.GetByCompanyId(company.Id);
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
// -----------------------------------------------------------------------
// <copyright file="CDHCompanyTracingMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Route = "/seguimiento";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;
            if (session.CurrentActivity?.Code != "search_by_page_entre_purchases_view")
            {
                IReadOnlyCollection<int> sales = this.DatMgr.Sale.GetSalesBySeller(session.EntityId);
                SearchData search = new SearchData(sales, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_purchases_view", null, "/welcomecompany", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Lista de ventas</b>\n");
            builder.AppendLine("Ingrese el numero de la venta para ver detalles.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextAllPublicationsBought(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron compras)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de inicio.");
            return builder.ToString();
        }

        private string TextAllPublicationsBought(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int saleId in search.PageItems)
            {
                Sale sale = this.DatMgr.Sale.GetById(saleId);
                CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(sale.ProductCompanyMaterialId);
                builder.AppendLine($"{sale.Id} - {compMat.Name}");
            }

            return builder.ToString();
        }
    }
}
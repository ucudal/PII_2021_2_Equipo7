// -----------------------------------------------------------------------
// <copyright file="CDH_History_Sale_Menu.cs" company="Universidad Católica del Uruguay">
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
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista compras hechas por el emprendedor.
    /// </summary>
    public class CDH_History_Sale_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_History_Sale_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_History_Sale_Menu(ChatDialogHandlerBase next)
        : base(next, "History_Sale_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "/compras";
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
                IReadOnlyCollection<int> sales = this.DatMgr.Sale.GetSalesByBuyer(session.EntityId);
                SearchData search = new SearchData(sales, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_purchases_view", null, "/welcome", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Lista de compras</b>\n");
            builder.AppendLine("Ingrese el numero de la compra para ver detalles.\n");
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
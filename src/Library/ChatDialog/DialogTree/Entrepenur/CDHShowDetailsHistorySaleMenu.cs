// -----------------------------------------------------------------------
// <copyright file="CDHShowDetailsHistorySaleMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista compras hechas por el emprendedor.
    /// </summary>
    public class CDHShowDetailsHistorySaleMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHShowDetailsHistorySaleMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHShowDetailsHistorySaleMenu(ChatDialogHandlerBase next)
        : base(next, "Show_Details_History_Sale_Menu")
        {
            this.Parents.Add("History_Sale_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("entrepreneur_sale_details", "welcome_entrepreneur", "/compras", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
            Sale sale = this.DatMgr.Sale.GetById(id);
            CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(sale.ProductCompanyMaterialId);
            Company comp = this.DatMgr.Company.GetById(sale.SellerCompanyId);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Detalles de Compra</b>\n");
            builder.AppendLine($"<b>Fecha</b>: {sale.DateTime.ToShortDateString()}");
            builder.AppendLine($"<b>Material</b>: {compMat.Name}");
            builder.AppendLine($"<b>Vendedor</b>: {comp.Name}");
            builder.AppendLine($"<b>Cantidad</b>: {sale.ProductQuantity}");
            builder.AppendLine($"<b>Moneda</b>: {Enum.GetName(typeof(Currency), sale.Currency)}");
            builder.AppendLine($"<b>Precio</b>: {sale.Price}\n");
            builder.Append("/volver - Volver.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        Sale sale = this.DatMgr.Sale.GetById(id);
                        if (sale is not null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
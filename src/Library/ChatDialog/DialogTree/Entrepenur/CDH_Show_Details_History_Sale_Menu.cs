// -----------------------------------------------------------------------
// <copyright file="CDH_Show_Details_History_Sale_Menu.cs" company="Universidad Católica del Uruguay">
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
    public class CDH_Show_Details_History_Sale_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Show_Details_History_Sale_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Show_Details_History_Sale_Menu(ChatDialogHandlerBase next)
        : base(next, "Show_Details_History_Sale_Menu")
        {
            this.Parents.Add("History_Sale_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            SearchSalesData data = new SearchSalesData();
            DProcessData process = new DProcessData("search_Sale", this.Code, data);
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            data.Sale = this.DatMgr.Sale.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            builder.Append("Datos de la venta:");
            builder.Append("Identificador de la venta" + data.Sale.Id);
            builder.Append("Nombre del material vendido" + this.DatMgr.CompanyMaterial.GetById(data.Sale.ProductCompanyMaterialId).Name);
            builder.Append("Precio de la compra" + data.Sale.Price);
            builder.Append("Cantidad:" + data.Sale.ProductQuantity);
            builder.Append("Fecha de compra" + data.Sale.DateTime.ToString(CultureInfo.InvariantCulture));
            builder.Append("Vendedor:" + this.DatMgr.User.GetById(data.Sale.SellerCompanyId).FirstName);
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            return builder.ToString();
        }
    }
}
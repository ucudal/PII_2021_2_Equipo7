// -----------------------------------------------------------------------
// <copyright file="CDH_Confirmation_Sale_Category.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la confirmación de la publicación por busqueda de categoria.
    /// </summary>
    public class CDH_Confirmation_Sale_Category : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Confirmation_Sale_Category"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Confirmation_Sale_Category(ChatDialogHandlerBase next)
        : base(next, "Confirmation_Sale_Category")
        {
            this.Parents.Add("Sale_Publication_Category");
            this.Route = "/comprar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            EntrepreneurPurchaseData data = activity.GetData<EntrepreneurPurchaseData>();

            Publication pub = this.DatMgr.Publication.GetById(data.PublicationId);
            Company comp = this.DatMgr.Company.GetById(pub.CompanyId);
            CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(pub.CompanyMaterialId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Resumen de Compra</b>\n");
            builder.AppendLine("Antes de confirmar la compra, verifique todos los datos de esta.\n");
            builder.AppendLine($"<b>Publicacion</b>: {pub.Title}");
            builder.AppendLine($"<b>Material</b>: {compMat.Name}");
            builder.AppendLine($"<b>Vendedor</b>: {comp.Name}");
            builder.AppendLine($"<b>Cantidad</b>: {pub.Quantity}");
            builder.AppendLine($"<b>Moneda</b>: {Enum.GetName(typeof(Currency), pub.Currency)}");
            builder.AppendLine($"<b>Precio</b>: {pub.Price}\n");
            builder.AppendLine("/confirmar - Confirma compra.\n");
            builder.Append("/volver - Cancelar la compra.");
            return builder.ToString();
        }
    }
}
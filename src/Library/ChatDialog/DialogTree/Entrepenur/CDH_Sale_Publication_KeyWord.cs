// -----------------------------------------------------------------------
// <copyright file="CDH_Sale_Publication_KeyWord.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la compra de la ´publicación.
    /// </summary>
    public class CDH_Sale_Publication_KeyWord : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Sale_Publication_KeyWord"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Sale_Publication_KeyWord(ChatDialogHandlerBase next)
        : base(next, "Sale_Publication_KeyWord")
        {
            this.Parents.Add("List_KeyWords_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            EntrepreneurPurchaseData data = new EntrepreneurPurchaseData(session.EntityId, id);
            UserActivity activity = new UserActivity("entrepreneur_pub_by_key_purchase", "Search_KeyWord_Menu", $"{id}", data);
            session.PushActivity(activity);

            Publication pub = this.DatMgr.Publication.GetById(id);
            Company comp = this.DatMgr.Company.GetById(pub.CompanyId);
            CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(pub.CompanyMaterialId);
            int stock = this.DatMgr.CompanyMaterialStock.GetStockTotalForCompanyMaterial(compMat.Id);
            IReadOnlyCollection<int> qualifications = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(pub.CompanyMaterialId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"<b>Detalles: {pub.Title}</b>\n");
            builder.AppendLine($"<b>Material</b>: {compMat.Name}");
            builder.AppendLine($"<b>Stock</b>: {stock}");
            builder.AppendLine($"<b>Vendedor</b>: {comp.Name}\n");
            builder.AppendLine($"<b>Descripcion</b>:\n{pub.Description}\n");
            builder.AppendLine("<b>Qualifications</b>:");
            bool hasAllQualifications = true;
            bool hasQualification;
            string line;
            foreach (int qualificationId in qualifications)
            {
                Qualification qualification = this.DatMgr.Qualification.GetById(qualificationId);
                hasQualification = this.DatMgr.EntrepreneurQualification.GetEntrepreneurHasQualification(session.EntityId, qualificationId);
                line = hasQualification ? $"{qualification.Name}" : $"{qualification.Name} (Falta)";
                builder.AppendLine(line);
                hasAllQualifications &= hasQualification;
            }

            builder.AppendLine($"\n<b>Cantidad</b>: {pub.Quantity}");
            builder.AppendLine($"<b>Moneda</b>: {Enum.GetName(typeof(Currency), pub.Currency)}");
            builder.AppendLine($"<b>Precio</b>: {pub.Price}\n");
            if (hasAllQualifications && stock != 0)
            {
                builder.AppendLine("/comprar : Comprar publicación.\n");
            }

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
                        Publication publication = this.DatMgr.Publication.GetById(id);
                        if (publication is not null)
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
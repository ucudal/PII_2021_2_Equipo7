// -----------------------------------------------------------------------
// <copyright file="CDH_Final_Sale_Keyword.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Realiza la transacción de la compra.
    /// </summary>
    public class CDH_Final_Sale_Keyword : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Final_Sale_Keyword"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Final_Sale_Keyword(ChatDialogHandlerBase next)
        : base(next, "Final_Sale_Keyword")
        {
            this.Parents.Add("Confirmation_Sale_KeyWord");
            this.Route = "\\confirmar";
        }

/// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            if (this.MakePurchase(session))
            {
                builder.Append("Compra realizada exitosamente \n");
            }
            else
            {
                builder.Append("La compra no se pudo realizar \n");
            }

            builder.Append("\\volver : Volver al menu principal.\n");
            return builder.ToString();
        }

        private bool MakePurchase(Session session)
        {
            bool xretorno = false;
            DProcessData process = session.Process;
            SearchPublication data = process.GetData<SearchPublication>();
            if (this.ReadyToBuy(data, session))
            {
                Sale compra = this.DatMgr.Sale.New();
                compra.Price = data.Publication.Price;
                compra.ProductCompanyMaterialId = data.Publication.CompanyMaterialId;
                compra.ProductQuantity = data.Publication.Quantity;
                compra.SellerCompanyId = data.Publication.CompanyId;
                compra.DateTime = System.DateTime.Now;
                compra.BuyerEntrepreneurId = session.UserId;
                compra.Currency = data.Publication.Currency;
                this.DatMgr.Sale.Insert(compra);
                xretorno = true;
            }

            return xretorno;
        }

        private bool ReadyToBuy(SearchPublication data, Session session)
        {
            CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(data.Publication.CompanyMaterialId);
            bool xretorno = false;

            // Si entra al if, significa que el material en esa ubicacion existe
            CompanyMaterialStock xMatStock = this.DatMgr.CompanyMaterialStock.GetCompanyMaterialStockByMatAndLocation(data.Publication.CompanyMaterialId, data.Publication.Location.Id);
            if (xMatStock != null)
            {
                if (xMatStock.Stock >= data.Publication.Quantity)
                {
                    // Hay el stock necesario y habilitaciones requeridas para realizar la compra
                    if (this.IsEnableToUseMat(xMat, session))
                    {
                        xretorno = true;
                        xMatStock.Stock = xMatStock.Stock - data.Publication.Quantity;
                        this.DatMgr.CompanyMaterialStock.Update(xMatStock);
                    }
                }
            }

            return xretorno;
        }

        private bool IsEnableToUseMat(CompanyMaterial pMat, Session session)
        {
            bool xretorno = false;
            IReadOnlyCollection<int> xQualificationList = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(pMat.Id);
            if (xQualificationList.Count > 0)
            {
                foreach (int i in xQualificationList)
                {
                    CompanyMaterialQualification xQuali = this.DatMgr.CompanyMaterialQualification.GetById(i);
                    if (xQuali != null)
                    {
                        User user = this.DatMgr.User.GetById(session.UserId);
                        if (this.DatMgr.EntrepreneurQualification.GetEntrepreneurHasQualification(user.Id, xQuali.Id))
                        {
                            xretorno = true;
                        }
                    }
                }
            }

            return xretorno;
        }
    }
}
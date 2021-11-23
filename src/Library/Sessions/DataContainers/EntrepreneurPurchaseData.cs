// -----------------------------------------------------------------------
// <copyright file="EntrepreneurPurchaseData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos de una
    /// compra por emprendedor.
    /// </summary>
    public class EntrepreneurPurchaseData : ActivityData
    {
        private int entrepreneurId;
        private int publicationId;
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntrepreneurPurchaseData"/>.
        /// </summary>
        /// <param name="entrepreneurId">
        /// Id del emprendedor que compra.
        /// </param>
        /// <param name="publicationId">
        /// Id de la publicacion que se compra.
        /// </param>
        public EntrepreneurPurchaseData(int entrepreneurId, int publicationId)
        {
            this.entrepreneurId = entrepreneurId;
            this.publicationId = publicationId;
        }

        /// <summary>
        /// Id del emprendedor que compra.
        /// </summary>
        public int EntrepreneurId { get => this.entrepreneurId; }

        /// <summary>
        /// Id de la publicacion que se compra.
        /// </summary>
        public int PublicationId { get => this.publicationId; }

        /// <summary>
        /// Acceso protegido al contenedor de administradores.
        /// </summary>
        public DataManager DatMgr
        {
            get => this.datMgr;
            set => this.datMgr = value;
        }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            Publication publication = this.DatMgr.Publication.GetById(this.publicationId);

            Sale sale = this.DatMgr.Sale.New();
            sale.DateTime = DateTime.Now;
            sale.Price = publication.Price;
            sale.ProductCompanyMaterialId = publication.CompanyMaterialId;
            sale.ProductQuantity = publication.Quantity;
            sale.SellerCompanyId = publication.CompanyId;
            sale.BuyerEntrepreneurId = this.entrepreneurId;
            sale.Currency = publication.Currency;
            int saleId = this.DatMgr.Sale.Insert(sale);

            return saleId != 0;
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyPublicationPriceMaterialToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationPriceMaterialToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationPriceMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationPriceMaterialToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_price_material_to_add_menu")
        {
            this.Parents.Add("company_publication_quantity_material_to_add_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.Publication.Quantity = int.Parse(selector.Code, CultureInfo.InvariantCulture);

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el precio que le quiere poner a la publicacion.\n");
            builder.Append("\\cancelar : En caso de querer canclear la operacion.\n");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            bool xretorno = false;
            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    xretorno = true;
                }
            }

            return xretorno;
        }
    }
}
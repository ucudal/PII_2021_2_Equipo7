// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationCurrencyMaterialToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationCurrencyMaterialToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationCurrencyMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationCurrencyMaterialToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_currency_material_to_add_menu")
        {
            this.Parents.Add("company_publication_price_material_to_add_menu");
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
            data.Publication.Price = int.Parse(selector.Code, CultureInfo.InvariantCulture);
            session.CurrentActivity = process;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Escoja la <b>moneda</b> a utilizar:\n");
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                if (currency != Currency.Undefined)
                {
                    builder.AppendLine(((int)currency) + " - " + Enum.GetName<Currency>(currency));
                }
            }

            builder.Append("\n/volver - En caso de querer canclear la operacion.");
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
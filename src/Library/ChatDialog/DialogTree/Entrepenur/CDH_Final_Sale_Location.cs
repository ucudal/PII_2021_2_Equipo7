// -----------------------------------------------------------------------
// <copyright file="CDHFinalSaleLocation.cs" company="Universidad Católica del Uruguay">
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
    public class CDHFinalSaleLocation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHFinalSaleLocation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHFinalSaleLocation(ChatDialogHandlerBase next)
        : base(next, "Final_Sale_Location")
        {
            this.Parents.Add("Confirmation_Sale_Location");
            this.Route = "/confirmar";
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

            data.RunTask();
            session.CurrentActivity.Terminate(chainInitiator: false);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Compra realizada exitosamente.\n");
            builder.Append("/inicio : Volver al menu principal.");
            return builder.ToString();
        }
    }
}
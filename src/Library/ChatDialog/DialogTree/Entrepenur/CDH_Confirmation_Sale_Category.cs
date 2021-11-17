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
            this.Route = "\\comprar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SearchPublication data = process.GetData<SearchPublication>();
            StringBuilder builder = new StringBuilder();
            builder.Append($"Quieres confirmar la compra de una publicación de Id - {data.Publication.Id} \n");
            builder.Append("\\confirmar : Confirma la compra la publicación\n");
            builder.Append("\\cancelar : Cancelar la compra\n");
            return builder.ToString();
        }
    }
}
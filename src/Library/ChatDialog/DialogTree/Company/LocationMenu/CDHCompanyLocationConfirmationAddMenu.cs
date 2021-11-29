// -----------------------------------------------------------------------
// <copyright file="CDHCompanyLocationConfirmationAddMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyLocationConfirmationAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyLocationConfirmationAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyLocationConfirmationAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_location_add_confirm_menu")
        {
            this.Parents.Add("company_location_add_menu");
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
            UserActivity activity = session.CurrentActivity;
            InsertCompanyLocationData data = activity.GetData<InsertCompanyLocationData>();
            data.CompLoc.GeoReference = selector.Code;
            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Seguro que desea añadir una localizacion con la siguiente direccion?\n");
            builder.AppendLine($"<b>Direccion</b>: {selector.Code}\n");
            builder.AppendLine("/confirmar - Confirmar la operacion.");
            builder.AppendLine("/volver - Volver al menu de localizaciones.");
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
                    return true;
                }
            }

            return false;
        }
    }
}
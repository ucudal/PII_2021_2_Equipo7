// -----------------------------------------------------------------------
// <copyright file="CDHCompanyLocationAddDoneMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyLocationAddDoneMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyLocationAddDoneMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyLocationAddDoneMenu(ChatDialogHandlerBase next)
        : base(next, "company_location_add_done_menu")
        {
            this.Parents.Add("company_location_add_confirm_menu");
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
            InsertCompanyLocationData data = activity.GetData<InsertCompanyLocationData>();
            data.RunTask();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("La localizacion se agrego satisfactoriamente.\n");
            builder.Append("/volver - Volver al menu de localizaciones.\n");
            return builder.ToString();
        }
    }
}
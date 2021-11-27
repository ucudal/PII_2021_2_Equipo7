// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationEraseDataMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyQualificationEraseDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationEraseDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationEraseDataMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualification_erase_data_menu")
        {
            this.Parents.Add("company_qualification_confirm_to_erase_menu");
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
            SelectCompanyMaterialQualificationData data = activity.GetData<SelectCompanyMaterialQualificationData>();
            data.RunTask();

            StringBuilder builder = new StringBuilder();
            builder.Append("La habilitacion se elimino con exito.\n");
            builder.Append("Escriba ");
            builder.Append("/volver : Para volver al menu de materiales .\n");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHCompanyConfirmationEraseMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyConfirmationEraseMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyConfirmationEraseMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyConfirmationEraseMaterialMenu(ChatDialogHandlerBase next)
            : base(next, "company_confirmation_erase_material_menu")
        {
            this.Parents.Add("company_actions_material_menu");
            this.Route = "/eliminar";
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
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Confirmar Eliminacion</b>\n");
            builder.AppendLine("¿Seguro que desea eliminar el material?");
            builder.AppendLine($"<b>Nombre</b>: {data.CompanyMaterial.Name}\n");
            builder.AppendLine("/confirmar - Confirmar eliminacion.");
            builder.Append("/volver - Volver al menu de materiales.");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_menu")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/materiales";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            UserActivity activity = new UserActivity("company_material_menu", null, "/welcome", null);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Menu de materiales</b>.\n");
            builder.AppendLine("Desde este menu puede realizar las siguientes operaciones:\n");
            builder.AppendLine("/ingresar - Agregar material.");
            builder.AppendLine("/listar - Listar materiales.\n");
            builder.Append("/volver - Volver al menu de empresa.");
            return builder.ToString();
        }
    }
}
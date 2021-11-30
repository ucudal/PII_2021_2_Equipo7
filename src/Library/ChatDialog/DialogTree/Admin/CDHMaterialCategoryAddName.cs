// -----------------------------------------------------------------------
// <copyright file="CDHMaterialCategoryAddName.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de la plataforma.
    /// </summary>
    public class CDHMaterialCategoryAddName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryAddName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryAddName(ChatDialogHandlerBase next)
            : base(next, "matcat_add_name")
        {
            this.Parents.Add("mat_menu");
            this.Route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            InsertMaterialCategoryData data = new InsertMaterialCategoryData();
            UserActivity activity = new UserActivity("comp_mat_cat_add", "welcome_sysadmin", "/materiales", data);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingrese el <b>nombre</b> del material:\n");
            builder.Append("/volver : Volver al menu de materiales.");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHMaterialCategoryRemoveFromList.cs" company="Universidad Católica del Uruguay">
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
    public class CDHMaterialCategoryRemoveFromList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryRemoveFromList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryRemoveFromList(ChatDialogHandlerBase next)
        : base(next, "material_remove_from_list")
        {
            this.Parents.Add("material_category_list");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            InsertMaterialCategoryData data = new InsertMaterialCategoryData
            {
                MaterialCategory = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture)),
            };

            UserActivity process = new UserActivity("remove_category", "mat_menu", "/listar", data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea eliminar la categoria del material.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
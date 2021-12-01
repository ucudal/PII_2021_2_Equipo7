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

            EraseMaterialCategoryData data = new EraseMaterialCategoryData
            {
                MatCatId = int.Parse(selector.Code, CultureInfo.InvariantCulture),
            };

            UserActivity process = new UserActivity("remove_category", "mat_menu", "/listar", data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.PushActivity(process);

            MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(data.MatCatId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Desea eliminar la siguiente categoria?\n");
            builder.AppendLine($"<b>Nombre:</b> {matCat.Name}\n");
            builder.AppendLine("/confirmar - Confirmar eliminacion.");
            builder.Append("/volver - Volver al listado de categorias.");
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
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(id);
                        if (matCat is not null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
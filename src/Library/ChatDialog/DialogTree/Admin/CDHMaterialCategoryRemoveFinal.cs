// -----------------------------------------------------------------------
// <copyright file="CDHMaterialCategoryRemoveFinal.cs" company="Universidad Católica del Uruguay">
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
    public class CDHMaterialCategoryRemoveFinal : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryRemoveFinal"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryRemoveFinal(ChatDialogHandlerBase next)
            : base(next, "matcat_remove_final")
        {
            this.Parents.Add("material_remove_from_list");
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
            EraseMaterialCategoryData data = session.CurrentActivity.GetData<EraseMaterialCategoryData>();

            StringBuilder builder = new StringBuilder();
            if (data.RunTask())
            {
                builder.AppendLine("Los datos se eliminaron correctamente.\n");
            }
            else
            {
                builder.AppendLine("Los datos no se pudieron eliminar .\n");
            }

            builder.Append("/volver - Volver al menu de materiales.\n");
            return builder.ToString();
        }
    }
}
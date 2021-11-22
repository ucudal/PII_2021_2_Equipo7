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

            StringBuilder builder = new StringBuilder();
            if (this.EraseMatcat(selector))
            {
                builder.Append("Los datos se eliminaron correctamente.\n");
            }
            else
            {
                builder.Append("Los datos no se pudieron eliminar .\n");
            }

            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }

        private bool EraseMatcat(ChatDialogSelector selector)
        {
            bool xretorno = false;
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertMaterialCategoryData data = process.GetData<InsertMaterialCategoryData>();
            MaterialCategory materialCategory = data.MaterialCategory;
            if (this.IsNotAllReadyToDelete(data) == false)
            {
                this.DatMgr.MaterialCategory.Delete(materialCategory.Id);
                xretorno = true;
            }

            return xretorno;
        }

        private bool IsNotAllReadyToDelete(InsertMaterialCategoryData data)
        {
            bool xretorno = false;
            foreach (MaterialCategory xMatCat in this.DatMgr.MaterialCategory.Items)
            {
                if (xMatCat.Id == data.MaterialCategory.Id)
                {
                    xretorno = true;
                }
            }

            return xretorno;
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHMateralCategoryFinal.cs" company="Universidad Católica del Uruguay">
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
    public class CDHMateralCategoryFinal : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMateralCategoryFinal"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMateralCategoryFinal(ChatDialogHandlerBase next)
        : base(next, "matcat_final")
        {
            this.Parents.Add("matcat_confir");
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
            this.MaterialCategoryAdd(selector);
            builder.Append("La categoria de material se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu .\n");
            return builder.ToString();
        }

        private void MaterialCategoryAdd(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertMaterialCategoryData data = process.GetData<InsertMaterialCategoryData>();
            MaterialCategory materialCategory = data.MaterialCategory;
            this.DatMgr.MaterialCategory.Insert(materialCategory);
        }
    }
}
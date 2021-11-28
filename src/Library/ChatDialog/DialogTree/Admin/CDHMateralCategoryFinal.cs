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

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            InsertMaterialCategoryData data = activity.GetData<InsertMaterialCategoryData>();

            StringBuilder builder = new StringBuilder();
            this.AddQualificationToMaterial(selector);
            builder.Append("categoria de material agregada con exito.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            data.RunTask();
            session.CurrentActivity.Terminate(chainInitiator: false);
            return builder.ToString();
        }

        private void AddQualificationToMaterial(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            InsertMaterialCategoryData data = activity.GetData<InsertMaterialCategoryData>();
            MaterialCategory compmat = this.DatMgr.MaterialCategory.New();
            compmat.Id = data.MaterialCategory.Id;

            this.DatMgr.MaterialCategory.Insert(compmat);
            session.CurrentActivity = activity;
        }
    }
}
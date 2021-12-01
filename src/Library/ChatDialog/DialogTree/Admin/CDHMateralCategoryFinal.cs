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
            data.RunTask();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Categoria de material agregada con exito.\n");
            builder.Append("/volver - Volver al menu de materiales.");
            session.CurrentActivity.Terminate(chainInitiator: false);
            return builder.ToString();
        }
    }
}
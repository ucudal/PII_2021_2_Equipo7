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
            UserActivity activity = session.CurrentActivity;
            InsertMaterialCategoryData data = activity.GetData<InsertMaterialCategoryData>();
            MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code,  CultureInfo.InvariantCulture));
            data.MaterialCategory = matCat;
            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre del material.\n");
            builder.Append("/volver : Volver al menu principal de compañía.\n");
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
                    MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code,  CultureInfo.InvariantCulture));
                    if (matCat is not null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
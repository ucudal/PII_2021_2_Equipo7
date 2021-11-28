// -----------------------------------------------------------------------
// <copyright file="CDHMaterialCategoryConfirm.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de la plataforma.
    /// </summary>
    public class CDHMaterialCategoryConfirm : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryConfirm"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryConfirm(ChatDialogHandlerBase next)
        : base(next, "matcat_confir")
        {
            this.Parents.Add("matcat_add_name");
            this.Route = null;
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
            InsertCompanyMaterialData data = activity.GetData<InsertCompanyMaterialData>();

            MaterialCategory companyMaterial = this.DatMgr.MaterialCategory.New();
            companyMaterial.Name = selector.Code.Trim();
            data.MaterialCategory = companyMaterial;

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");
            builder.Append("Nombre: " + data.CompanyMaterial.Name);
            builder.Append("/confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("/volver : Volver al menu principal de compañía");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            bool xretorno = false;

            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    xretorno = true;
                }
            }

            return xretorno;
        }
    }
}
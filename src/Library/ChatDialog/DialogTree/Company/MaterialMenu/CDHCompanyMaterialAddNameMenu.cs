// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialAddNameMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialAddNameMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialAddNameMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialAddNameMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_add_name_menu")
        {
            this.Parents.Add("company_add_menu");
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
            MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code,  CultureInfo.InvariantCulture));
            data.MaterialCategory = matCat;
            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingrese el <b>nombre</b> del material.\n");
            builder.Append("/volver - Volver al menu de materiales.");
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
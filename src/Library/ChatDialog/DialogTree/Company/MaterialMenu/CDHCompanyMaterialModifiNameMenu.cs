// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialModifiNameMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialModifiNameMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiNameMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiNameMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_modifi_name_menu")
        {
            this.Parents.Add("company_modifi_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            SelectCompanyMaterialData data = new SelectCompanyMaterialData();

            data.MaterialCategory=matCat;
            UserActivity process = new UserActivity("modifi_material", null, this.Code, data);

            data.MaterialCategory = matCat;
            DProcessData process = new DProcessData("modifi_material", this.Code, data);

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre del material.\n");
            builder.Append("\\cancelar : Volvemos al menu de Modifciacion.\n");
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
                    MaterialCategory matCat = this.DatMgr.MaterialCategory.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
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
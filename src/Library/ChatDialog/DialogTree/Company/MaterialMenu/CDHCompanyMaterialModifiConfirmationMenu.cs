// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialModifiConfirmationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialModifiConfirmationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiConfirmationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiConfirmationMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_modifi_confirmation_menu")
        {
            this.Parents.Add("company_material_modifi_dateBetweenReStock_menu");
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
            UserActivity process = session.CurrentActivity;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.CompanyMaterial.DateBetweenRestocks = int.Parse(selector.Code, CultureInfo.InvariantCulture);

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea crear un material con los siguientes datos.\n");

            builder.Append("Nombre: " + data.CompanyMaterial.Name + "\n");
            builder.Append("Categoria: " + data.MaterialCategory.Name + "\n");
            builder.Append("Cantidad: " + data.CompanyMaterialStock.Stock + "\n");
            builder.Append("Ubicacion: " + this.DatMgr.CompanyLocation.GetById(data.CompanyMaterialStock.CompanyLocationId).GeoReference + "\n");
            builder.Append("Re-Establecimiento de stock cada: " + data.CompanyMaterial.DateBetweenRestocks + "\n");

            builder.Append("DATOS\n");
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("\\cancelar : En caso de querer cancelar la operacion.\n");
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
                    return true;
                }
            }

            return false;
        }
    }
}
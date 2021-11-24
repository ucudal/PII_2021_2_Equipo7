// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialModifiDateBetweenReStockMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialModifiDateBetweenReStockMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiDateBetweenReStockMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiDateBetweenReStockMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_modifi_dateBetweenReStock_menu")
        {
            this.Parents.Add("company_material_modifi_ubication_menu");
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

            UserActivity process = session.CurrentActivity;;
            session.CurrentActivity = process;

            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.CompanyMaterialStock.CompanyLocationId = int.Parse(selector.Code, CultureInfo.InvariantCulture);
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese la ubicacion del material.\n");
            builder.Append("\\cancelar : Listar todos los materiales que ya posee.\n");
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
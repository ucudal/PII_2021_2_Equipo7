// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialModifiUbicationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialModifiUbicationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialModifiUbicationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialModifiUbicationMenu(ChatDialogHandlerBase next)
            : base(next, "company_material_modifi_ubication_menu")
        {
            this.Parents.Add("company_material_modifi_quantity_menu");
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

            DProcessData process = session.Process;
            session.Process = process;

            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            data.CompanyMaterialStock.Stock = int.Parse(selector.Code, CultureInfo.InvariantCulture);
            data.CompanyMaterialStock.CompanyMatId = data.CompanyMaterial.Id;

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
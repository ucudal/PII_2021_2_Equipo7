// -----------------------------------------------------------------------
// <copyright file="CDH_Material_Regeneration_ShowDetail_Menu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDH_Material_Regeneration_ShowDetail_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Material_Regeneration_ShowDetail_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Material_Regeneration_ShowDetail_Menu(ChatDialogHandlerBase next)
        : base(next, "Material_Regeneration_ShowDetail_Menu")
        {
            this.Parents.Add("Material_Regeneration_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            builder.Append("Detalles del material elegido. \n");
            builder.Append("El nombre del material es " + xMat.Name + " \n");
            builder.Append("El material se regenera cada " + xMat.DateBetweenRestocks + " dias \n");
            builder.Append("El nombre de la compañía que vende le material es " + this.DatMgr.Company.GetById(xMat.CompanyId).Name + " \n");
            builder.Append("\\volver para volver");
            return builder.ToString();
        }
    }
}
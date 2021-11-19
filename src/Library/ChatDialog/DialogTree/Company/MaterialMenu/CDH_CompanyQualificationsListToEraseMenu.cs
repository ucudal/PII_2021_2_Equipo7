// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyQualificationsListToEraseMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationsListToEraseMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationsListToEraseMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationsListToEraseMenu(ChatDialogHandlerBase next)
        : base(next, "company_qualifications_list_to_erase_menu")
        {
            this.Parents.Add("company_qualifications_menu");
            this.Route = "/eliminar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de habilitaciones del material.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la habilitacion que desea eliminar, \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            builder.Append(this.TextoToPrintQualificationsToErase(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }

        private string TextoToPrintQualificationsToErase(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            IReadOnlyCollection<int> xHabilitacionesAgregadas = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(data.CompanyMaterial.Id);
            foreach (int i in xHabilitacionesAgregadas)
            {
                CompanyMaterialQualification xHabili = this.DatMgr.CompanyMaterialQualification.GetById(xHabilitacionesAgregadas.ElementAt(i));
                builder.Append(" " + this.DatMgr.CompanyMaterial.GetById(xHabili.CompanyMatId).Name + " " + this.DatMgr.Qualification.GetById(xHabili.QualificationId).Id + "\n");
            }

            return builder.ToString();
        }
    }
}
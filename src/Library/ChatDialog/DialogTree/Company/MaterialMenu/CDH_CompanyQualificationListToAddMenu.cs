// -----------------------------------------------------------------------
// <copyright file="CDH_CompanyQualificationListToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyQualificationListToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationListToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationListToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualification_list_to_add_menu")
        {
            this.Parents.Add("company_qualifications_menu");
            this.Route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Menu lista de habilitaciones.\n");
            builder.Append("Aparecen la lista de habilitaciones que puede agregar.\n");
            builder.Append("Ingrese el numero de la habilitacion que quiere agregar.\n");
            builder.Append("Sino, en caso de querer retornar escriba\n");
            builder.Append("\\volver para volver al menu de materiales.\n");
            builder.Append(this.TextoToPrintQualifications(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }

        private string TextoToPrintQualifications(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            List<Qualification> xhabilitacionesNoAgegadas = new List<Qualification>();
            int i = 0;
            bool xSigo = true;
            foreach (Qualification xHabi in this.DatMgr.Qualification.Items)
            {
                xSigo = true;
                IReadOnlyCollection<int> xHabilitaciones = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(data.CompanyMaterial.Id);
                while (i < xHabilitaciones.Count && xSigo == true)
                {
                   if (xHabi.Id == xHabilitaciones.ElementAt(i))
                   {
                       xSigo = false;
                       xhabilitacionesNoAgegadas.Add(xHabi);
                   }
                }
            }

            foreach (Qualification x in xhabilitacionesNoAgegadas)
            {
                builder.Append(" " + x.Name + " " + x.Id + "\n");
            }

            return builder.ToString();
        }
    }
}
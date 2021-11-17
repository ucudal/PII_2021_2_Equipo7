// -----------------------------------------------------------------------
// <copyright file="CDH_Qualifications_List_Menu.cs" company="Universidad Católica del Uruguay">
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
    /// Lista de habilitaciones de un emprendedor.
    /// </summary>
    public class CDH_Qualifications_List_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase. <see cref="CDH_Qualifications_List_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_List_Menu(ChatDialogHandlerBase next)
        : base(next, "Qualifications_List_Menu")
        {
            this.Parents.Add("Qualification_Menu");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de habilitaciones\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la habilitacion para ver detalles. \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            builder.Append(this.TextoToPrintQualificationsToErase(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }

        private string TextoToPrintQualificationsToErase(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            IReadOnlyCollection<int> habilitacion = this.DatMgr.EntrepreneurQualification.GetQualificationsForEntrepreneur(session.UserId);
            foreach (int i in habilitacion)
            {
                EntrepreneurQualification habili = this.DatMgr.EntrepreneurQualification.GetById(habilitacion.ElementAt(i));
                builder.Append($" Nombre de la habilitación {this.DatMgr.Qualification.GetById(habili.EntrepreneurId).Name} de id {this.DatMgr.Qualification.GetById(habili.EntrepreneurId).Id} \n");
            }

            return builder.ToString();
        }
    }
}
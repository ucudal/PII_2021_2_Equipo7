// -----------------------------------------------------------------------
// <copyright file="CDH_Qualifications_Add_Menu.cs" company="Universidad Católica del Uruguay">
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
    /// Menú para añadir habilitación.
    /// </summary>
    public class CDH_Qualifications_Add_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Add_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Add_Menu(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Add_Menu")
        {
            this.Parents.Add("Qualification_Menu");
            this.Route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu lista de habilitaciones.\n");
            builder.Append("lista de habilitaciones que puede agregar.\n");
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
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            List<Qualification> habilitacionesNoAgegadas = new List<Qualification>();
            int i = 0;
            bool sigo = true;
            foreach (Qualification habi in this.DatMgr.Qualification.Items)
            {
                sigo = true;
                IReadOnlyCollection<int> habilitaciones = this.DatMgr.EntrepreneurQualification.GetQualificationsForEntrepreneur(session.UserId);
                while (i < habilitaciones.Count && sigo == true)
                {
                   if (habi.Id == habilitaciones.ElementAt(i))
                   {
                       sigo = false;
                       habilitacionesNoAgegadas.Add(habi);
                   }
                }
            }

            foreach (Qualification x in habilitacionesNoAgegadas)
            {
                builder.Append(" " + x.Name + " " + x.Id + "\n");
            }

            return builder.ToString();
        }
    }
}
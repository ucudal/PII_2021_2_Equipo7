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
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;
            if (session.CurrentActivity.Code != "search_by_page_entre_qual_ins_1")
            {
                IReadOnlyCollection<int> qualifications = this.DatMgr.Qualification.Items.Select(qual => qual.Id).ToList().AsReadOnly();
                SearchData search = new SearchData(qualifications, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_qual_ins_1", null, null, search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Agregar habilitacion</b>.\n");
            builder.Append("El siguiente listado contiene todas las habilitaciones que puede agregar. ");
            builder.AppendLine("Escoja una para poder continuar.");
            builder.AppendLine(this.TextoToPrintQualifications(activity.GetData<SearchData>()));
            builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
            builder.AppendLine("/pagina_anterior - Pagina anterior.");
            builder.AppendLine("/volver - Volver al menu de habilitaciones.");
            return builder.ToString();
        }

        private string TextoToPrintQualifications(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int qualificationId in search.PageItems)
            {
                Qualification qualification = this.DatMgr.Qualification.GetById(qualificationId);
                builder.AppendLine($"{qualificationId} - {qualification.Name}");
            }

            return builder.ToString();
        }
    }
}
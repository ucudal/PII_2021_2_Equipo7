// -----------------------------------------------------------------------
// <copyright file="CDHQualificationsListMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHQualificationsListMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase. <see cref="CDHQualificationsListMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationsListMenu(ChatDialogHandlerBase next)
            : base(next, "Qualifications_List_Menu")
        {
            this.Parents.Add("Qualification_Menu");
            this.Route = "/listar";
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
            if (session.CurrentActivity.Code != "search_by_page_entre_qual_view")
            {
                IReadOnlyCollection<int> qualifications = this.DatMgr.EntrepreneurQualification.GetQualificationsForEntrepreneur(session.EntityId);
                SearchData search = new SearchData(qualifications, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_qual_view", "welcome_entrepreneur", "/habilitaciones", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Lista de habilitaciones</b>\n");
            builder.AppendLine("Ingrese el numero de la habilitacion para ver detalles.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextoToPrintQualifications(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron habilitaciones)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de habilitaciones.");
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
                EntrepreneurQualification entreQual = this.DatMgr.EntrepreneurQualification.GetById(qualificationId);
                Qualification qualification = this.DatMgr.Qualification.GetById(entreQual.QualificationId);
                builder.AppendLine($"{entreQual.Id} - {qualification.Name}");
            }

            return builder.ToString();
        }
    }
}
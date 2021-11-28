// -----------------------------------------------------------------------
// <copyright file="CDHInviteCompanyExistList.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHInviteCompanyExistList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteCompanyExistList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteCompanyExistList(ChatDialogHandlerBase next)
        : base(next, "invite_company_exist_list")
        {
            this.Parents.Add("invitemenu");
            this.Route = "/compania_existente";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;
            if (session.CurrentActivity.Code != "search_by_page_admin_inv_comp_join")
            {
                int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
                IReadOnlyCollection<int> companies = this.DatMgr.Company.Items.Select(comp => comp.Id).ToList().AsReadOnly();

                InsertInvitationData search = new InsertInvitationData(companies, this.Parents.First(), this.Route);
                activity = new UserActivity("inv_companyJoin_ins", null, "/invitar", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            InsertInvitationData data = activity.GetData<InsertInvitationData>();
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintQualification(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron companias)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        private string TextToPrintQualification(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int compid in search.PageItems)
            {
                Company comp = this.DatMgr.Company.GetById(compid);
                builder.AppendLine($"{comp.Id} - {comp.Name}");
            }

            return builder.ToString();
        }
    }
}
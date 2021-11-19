// -----------------------------------------------------------------------
// <copyright file="CDH_NextPage.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// asd.
    /// </summary>
    public class CDH_NextPage : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase. <see cref="CDH_NextPage"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_NextPage(ChatDialogHandlerBase next)
            : base(next, "list_next_page")
        {
            this.Route = "/pagina_siguiente";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            SearchData search = activity.GetData<SearchData>();

            search.NextPage();
            activity.SetHandlerChain(search.SearchPageContext, search.SearchPageRoute);
            session.CurrentActivity = activity;

            return null;
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Route == selector.Code)
            {
                Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                UserActivity activity = session.CurrentActivity;

                if (activity.Code.StartsWith("search_by_page", StringComparison.InvariantCulture))
                {
                  return true;
                }
            }

            return false;
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHPrevPage.cs" company="Universidad Católica del Uruguay">
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
    public class CDHPrevPage : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase. <see cref="CDHPrevPage"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHPrevPage(ChatDialogHandlerBase next)
            : base(next, "list_prev_page")
        {
            this.Route = "/pagina_anterior";
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

            search.PrevPage();
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
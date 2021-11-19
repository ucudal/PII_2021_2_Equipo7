// -----------------------------------------------------------------------
// <copyright file="CDH_List_KeyWords_Menu.cs" company="Universidad Católica del Uruguay">
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
    /// Muestra una lista de publicaciones.
    /// </summary>
    public class CDH_List_KeyWords_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_List_KeyWords_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_List_KeyWords_Menu(ChatDialogHandlerBase next)
        : base(next, "List_KeyWords_Menu")
        {
            this.Parents.Add("Search_KeyWord_Menu");
            this.Route = null;
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
            if (session.CurrentActivity.Code != "search_by_page_entre_pubs_key_results")
            {
                IReadOnlyCollection<int> pubKeyWords = this.DatMgr.PublicationKeyWord.GetPublicationFromKeyWord(selector.Code);
                SearchData search = new SearchData(pubKeyWords, this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_pubs_key_results", "Search_Publication_Menu", "/palabraclave", search);
                session.PushActivity(activity);
            }

            activity = session.CurrentActivity;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Resultados por Palabra Clave</b>\n");
            builder.AppendLine($"Ingrese un id para ver detalles y/o realizar una compra.\n");
            builder.AppendLine(this.TextToPrintPublication(activity.GetData<SearchData>()));
            builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
            builder.AppendLine("/pagina_anterior - Pagina anterior.");
            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        private string TextToPrintPublication(SearchData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int pubId in search.PageItems)
            {
                Publication pub = this.DatMgr.Publication.GetById(pubId);
                builder.AppendLine($"{pub.Id} - {pub.Title}");
            }

            return builder.ToString();
        }
    }
}
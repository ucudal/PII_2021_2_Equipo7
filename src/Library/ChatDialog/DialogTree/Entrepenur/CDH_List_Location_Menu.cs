// -----------------------------------------------------------------------
// <copyright file="CDH_List_Location_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Ucu.Poo.Locations.Client;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones por localidad.
    /// </summary>
    public class CDH_List_Location_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_List_Location_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_List_Location_Menu(ChatDialogHandlerBase next)
        : base(next, "List_Location_Menu")
        {
            this.Parents.Add("Search_Location_Menu");
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
            if (session.CurrentActivity.Code != "search_by_page_entre_pubs_loc_results")
            {
                LocationApiClient locApi = new LocationApiClient();
                IList<Publication> publ = this.DatMgr.Publication.Items.ToList();
                Location location = locApi.GetLocation(selector.Code);
                IList<Task<int>> apiCalls = publ.Select(pub => this.IdForCloseOrDefault(pub, location)).ToList();
                IList<int> closePublications = AsyncContext.Run(() => RunAllDistanceCalcs(apiCalls));
                while (closePublications.Remove(0))
                {
                }

                SearchData search = new SearchData(closePublications.ToList().AsReadOnly(), this.Parents.First(), this.Route);
                activity = new UserActivity("search_by_page_entre_pubs_loc_results", "Search_Publication_Menu", "/localidad", search);
                session.PushActivity(activity);
                locApi.Dispose();
            }

            activity = session.CurrentActivity;
            SearchData data = activity.GetData<SearchData>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<b>Resultados por Localidad</b>\n");
            builder.AppendLine($"Ingrese un id para ver detalles y/o realizar una compra.\n");
            if (data.SearchResults.Count > 0)
            {
                builder.AppendLine($"{this.TextToPrintPublicationMaterialLocation(data)}");
            }
            else
            {
                builder.AppendLine("(No se encontraron publicaciones)\n");
            }

            if (data.PageItemCount < data.SearchResults.Count)
            {
                builder.AppendLine("/pagina_siguiente - Pagina siguiente.");
                builder.AppendLine("/pagina_anterior - Pagina anterior.\n");
            }

            builder.Append("/volver - Volver al menu de busqueda.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    return true;
                }
            }

            return false;
        }

        private static async Task<IList<int>> RunAllDistanceCalcs(IList<Task<int>> distanceCalcTasks)
        {
            IList<int> results = await Task.WhenAll(distanceCalcTasks).ConfigureAwait(false);
            return results;
        }

        private string TextToPrintPublicationMaterialLocation(SearchData search)
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

        private async Task<int> IdForCloseOrDefault(Publication publication, Location entreLoc)
        {
            LocationApiClient locApi = new LocationApiClient();

            CompanyLocation compLoc = this.DatMgr.CompanyLocation.GetById(publication.CompanyLocationId);
            Location compLocObj = await locApi.GetLocationAsync(compLoc.GeoReference).ConfigureAwait(false);
            Distance distance = await locApi.GetDistanceAsync(entreLoc, compLocObj).ConfigureAwait(false);

            locApi.Dispose();
            return distance.TravelDistance <= 20000 ? publication.Id : 0;
        }
    }
}
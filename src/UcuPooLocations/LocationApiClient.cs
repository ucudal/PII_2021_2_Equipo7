//-----------------------------------------------------------------------------------
// <copyright file="LocationApiClient.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Nito.AsyncEx;

namespace Ucu.Poo.Locations.Client
{
    /// <summary>
    /// Un cliente de la API de localización.
    /// </summary>
    public class LocationApiClient : IDisposable
    {
        private const string BaseUrl = "https://pii-locationapi.azurewebsites.net";

        private HttpClient client = new HttpClient();

        private bool disposedValue;

        private static string DistanceUrl
        {
            get
            {
                return BaseUrl + "/distance";
            }
        }

        private static string LocationUrl
        {
            get
            {
                return BaseUrl + "/location";
            }
        }

        private static string MapUrl
        {
            get
            {
                return BaseUrl + "/map";
            }
        }

        private static string RouteUrl
        {
            get
            {
                return BaseUrl + "/route";
            }
        }

        /// <summary>
        /// Obtiene las coordenadas de una dirección.
        /// </summary>
        /// <param name="address">La dirección.</param>
        /// <param name="city">La ciudad. Es opcional. El valor predeterminado es Montevideo.</param>
        /// <param name="department">El departamento, estado, provincia, etc. Es opcional. El valor predeterminado es `ontevideo.</param>
        /// <param name="country">El país. Es opcional. El valor predeterminado es Uruguay.</param>
        /// <returns>Las coordenadas de la dirección.</returns>
        public async Task<Location> GetLocationAsync(
            string address,
            string city = "Montevideo",
            string department = "Montevideo",
            string country = "Uruguay")
        {
            var parameters = new Dictionary<string, string>
            {
                { "address", address },
                { "city", city },
                { "department", department },
                { "country", country },
            };

            var requestUri = GetUri(LocationUrl, parameters);

            Location result;

            using (var response = await this.client.GetAsync(requestUri).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonSerializer.Deserialize<Location>(
                    content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return result;
        }

        /// <inheritdoc cref="GetLocationAsync" />
        /// <remarks>
        /// Versión sincrónica.
        /// </remarks>
        public Location GetLocation(
            string address,
            string city = "Montevideo",
            string department = "Montevideo",
            string country = "Uruguay")
        {
            return AsyncContext.Run(() => this.GetLocationAsync(address, city, department, country));
        }

        /// <summary>
        /// Obtiene la distancia entre dos coordenadas.
        /// </summary>
        /// <param name="from">La coordenada de origen.</param>
        /// <param name="to">La coordenada de destino.</param>
        /// <returns>La distancia entre las dos coordenadas.</returns>
        public async Task<Distance> GetDistanceAsync(Location from, Location to)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fromLatitude", from.Latitude.ToString(CultureInfo.InvariantCulture) },
                { "fromLongitude", from.Longitude.ToString(CultureInfo.InvariantCulture) },
                { "toLatitude", to.Latitude.ToString(CultureInfo.InvariantCulture) },
                { "toLongitude", to.Longitude.ToString(CultureInfo.InvariantCulture) },
            };

            var requestUri = GetUri(DistanceUrl, parameters);
            using (var response = await this.client.GetAsync(requestUri).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Distance result = JsonSerializer.Deserialize<Distance>(
                    content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return result;
            }
        }

        /// <inheritdoc cref="GetDistanceAsync(Location,Location)" />
        /// <remarks>
        /// Versión sincrónica.
        /// </remarks>
        public Distance GetDistance(Location from, Location to)
        {
            return AsyncContext.Run(() => this.GetDistanceAsync(from, to));
        }

        /// <summary>
        /// Obtiene la distancia entre dos direcciones.
        /// </summary>
        /// <param name="from">La dirección de origen.</param>
        /// <param name="to">La dirección de destino.</param>
        /// <returns>La distancia entre las dos direcciones.</returns>
        public async Task<Distance> GetDistanceAsync(string from, string to)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fromAddress", from },
                { "toAddress", to },
            };

            var requestUri = GetUri(DistanceUrl, parameters);
            using var response = await this.client.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Distance result = JsonSerializer.Deserialize<Distance>(
                content,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return result;
        }

        /// <inheritdoc cref="GetDistanceAsync(string,string)" />.
        /// <remarks>
        /// Versión sincrónica.
        /// </remarks>
        public Distance GetDistance(string from, string to)
        {
            return AsyncContext.Run(() => this.GetDistanceAsync(from, to));
        }

        /// <summary>
        /// Descarga una mapa de una coordenada.
        /// </summary>
        /// <param name="latitude">La latitud de la coordenada.</param>
        /// <param name="longitude">La longitud de la coordenada.</param>
        /// <param name="path">La ruta del archivo donde guardar el mapa. El formato es PNG.</param>
        /// <param name="zoomLevel">El nivel de zoom del mapa entre 1 y 20. Es opcional. El valor predeterminado es
        /// 15.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// </returns>
        public async Task DownloadMapAsync(double latitude, double longitude, string path, int zoomLevel = 15)
        {
            var parameters = new Dictionary<string, string>
            {
                { "latitude", latitude.ToString(CultureInfo.InvariantCulture) },
                { "longitude", longitude.ToString(CultureInfo.InvariantCulture) },
                { "zoomLevel", zoomLevel.ToString(CultureInfo.InvariantCulture) },
            };

            var requestUri = GetUri(MapUrl, parameters);
            using var response = await this.client.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            await response.Content.CopyToAsync(fs).ConfigureAwait(false);
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <inheritdoc cref="LocationApiClient.DownloadMapAsync(double, double, string, int)" />.
        /// <remarks>
        /// Versión sincrónica.
        /// </remarks>
        public void DownloadMap(double latitude, double longitude, string path, int zoomLevel = 15)
        {
            AsyncContext.Run(() => this.DownloadMapAsync(latitude, longitude, path, zoomLevel));
        }

        /// <summary>
        /// Un mapa con una ruta entre dos coordenadas.
        /// </summary>
        /// <param name="fromLatitude">La latitud de la coordenada de origen.</param>
        /// <param name="fromLongitude">La longitu de la coordenada de origen.</param>
        /// <param name="toLatitude">La latitud de la coordenada de destino.</param>
        /// <param name="toLongitude">La longitud de la coordenada de destino.</param>
        /// <param name="path">La ruta del archivo donde guardar el mapa. Es formato es PNG.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// </returns>
        public async Task DownloadRouteAsync(
            double fromLatitude,
            double fromLongitude,
            double toLatitude,
            double toLongitude,
            string path)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fromLatitude", fromLatitude.ToString(CultureInfo.InvariantCulture) },
                { "fromLongitude", fromLongitude.ToString(CultureInfo.InvariantCulture) },
                { "toLatitude", toLatitude.ToString(CultureInfo.InvariantCulture) },
                { "toLongitude", toLongitude.ToString(CultureInfo.InvariantCulture) },
            };

            var requestUri = GetUri(RouteUrl, parameters);
            using var response = await this.client.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            await response.Content.CopyToAsync(fs).ConfigureAwait(false);
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <inheritdoc cref="LocationApiClient.DownloadRouteAsync(double, double, double, double, string)" />
        /// <remarks>
        /// Versión sincrónica.
        /// </remarks>
        public void DownloadRoute(
            double fromLatitude,
            double fromLongitude,
            double toLatitude,
            double toLongitude,
            string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Is null or empty", nameof(path));
            }

            AsyncContext.Run(() => this.DownloadRouteAsync(fromLatitude, fromLongitude, toLatitude, toLongitude, path));
        }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc cref="IDisposable" />
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.client.Dispose();
                }

                this.disposedValue = true;
            }
        }

        private static Uri GetUri(string baseUrl, IDictionary<string, string> parameters)
        {
            return new Uri(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}?{1}",
                    baseUrl,
                    string.Join(
                        "&",
                        parameters.Select(kvp =>
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "{0}={1}",
                            kvp.Key,
                            HttpUtility.UrlEncode(kvp.Value))))));
        }
    }
}

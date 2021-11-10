//--------------------------------------------------------------------------------
// <copyright file="Distance.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Ucu.Poo.Locations.Client
{
    /// <summary>
    /// Representa la distancia entre las coordenas o las direcciones de origen y destino retornada en los métodos
    /// <see cref="LocationApiClient.GetDistanceAsync(Location, Location)"/> o
    /// <see cref="LocationApiClient.GetDistanceAsync(string, string)"/>.
    /// </summary>
    public class Distance
    {
        /// <summary>
        /// Obtiene o establece un valor que indica si se encontraron o no las coordenas o las direcciones de origen y
        /// destino.
        /// </summary>
        /// <value>true si se encontró la dirección; false en caso contrario.</value>
        public bool Found { get; set; }

        /// <summary>
        /// Obtiene o establece la distancia entre las coordenadas o las direcciones de origen y destino.
        /// </summary>
        /// <value>La distancia en metros.</value>
        public double TravelDistance { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo que se demora en llegar de las coordenadas o de las direcciones de origen a las de destino.
        /// </summary>
        /// <value>El tiempo que se demora en minutos.</value>
        public double TravelDuration { get; set; }
    }
}
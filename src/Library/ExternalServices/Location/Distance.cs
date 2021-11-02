namespace ClassLibrary.Services.Location.Client
{
    /// <summary>
    /// Representa la distancia entre las coordenadas o las direcciones de origen y destino retornada en los métodos
    /// <see cref="LocationAPIClient.GetDistanceAsync(Location, Location)"/> o
    /// <see cref="LocationAPIClient.GetDistanceAsync(string, string)"/>.
    /// </summary>
    public class Distance
    {
        /// <summary>
        /// Indica si se encontraron o no las coordenadas o las direcciones de origen y destino.
        /// </summary>
        /// <value>true si se encontró la dirección; false en caso contrario.</value>
        public bool Found { get; set; }

        /// <summary>
        /// La distancia entre las coordenadas o las direcciones de origen y destino.
        /// </summary>
        /// <value>La distancia en metros.</value>
        public double TravelDistance { get; set; }

        /// <summary>
        /// El tiempo que se demora en llegar de las coordenadas o de las direcciones de origen a las de destino.
        /// </summary>
        /// <value>El tiempo que se demora en minutos.</value>
        public double TravelDuration { get; set; }
    }
}
namespace ClassLibrary
{
    /// <summary>
    /// Interface para estructuras de datos que
    /// deben ser administradas por una implementacion
    /// concreta de <see cref="DataAdmin{T}"/>. 
    /// </summary>
    public interface IManagableData
    {
        /// <summary>
        /// Identificador del registro de la estructura.
        /// </summary>
        int Id { get; set; }
        
        /// <summary>
        /// Flag de la baja logica del registro.
        /// </summary>
        bool Deleted { get; set; }
    }
}
namespace ClassLibrary
{
    /// <summary>
    /// Interface para estructuras de datos que
    /// deben ser administradas por una implementacion
    /// concreta de <see cref="DataAdmin{T}"/>. 
    /// </summary>
    public interface IManagableData<T>
    {
        /// <summary>
        /// Identificador del registro de la estructura.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Flag de la baja logica del registro.
        /// </summary>
        bool Deleted { get; set; }

        /// <summary>
        /// Cargar las propiedades del objeto desde un Json.
        /// </summary>
        /// <param name="json">Cadena json con los datos del objeto.</param>
        void LoadFromJson(string json);

        /// <summary>
        /// Convierte el objeto a json.
        /// </summary>
        /// <returns>Cadena Json con los datos del objeto.</returns>
        string ConvertToJson();

        /// <summary>
        /// Devuelve un nuevo objeto equivalente pero no identico
        /// al cual se le envia el mensaje.
        /// </summary>
        /// <returns>Copia por miembro de un objeto.</returns>
        T Clone();
    }
}
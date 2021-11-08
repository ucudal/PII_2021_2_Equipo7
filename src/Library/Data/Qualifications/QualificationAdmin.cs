using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para la administración de las habilitaciones.
    /// </summary>
    public sealed class QualificationAdmin : DataAdmin<Qualification>
    {
        /// <inheritdoc/>
        protected override void ValidateData(Qualification item)
        {
            if(item.Name is null || item.Name.Length == 0) 
                throw new ValidationException("Requerido nombre.");
        }
    }
}
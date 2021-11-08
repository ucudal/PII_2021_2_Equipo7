using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public sealed class MaterialCategoryAdmin : DataAdmin<MaterialCategory>
    {
        /// <inheritdoc/>
        protected override void ValidateData(MaterialCategory item)
        {
            if(item.Name is null || item.Name.Length == 0) 
                throw new ValidationException("Requerido nombre.");
        }
    }
}
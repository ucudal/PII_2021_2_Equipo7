using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// clase administradora de company
    /// </summary>
    public class CompanyAdmin: DataAdmin<Company>
    {

        /// <summary>
        /// Obtiene una compania por
        /// su nombre.
        /// </summary>
        /// <param name="name">
        /// Nombre por el cual buscar.
        /// </param>
        /// <returns>
        /// Compania encontrada.
        /// </returns>
        public Company GetByName(string name)
        {
            ReadOnlyCollection<Company> companies = this.Items;
            foreach (Company comp in companies)
            {
                if (comp.Name == name)
                {
                    return comp.Clone();
                }
            }
            
            return null;
        }
    }
}
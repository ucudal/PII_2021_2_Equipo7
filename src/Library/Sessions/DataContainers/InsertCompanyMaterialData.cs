namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class InsertCompanyMaterialData
    {
       private CompanyMaterial companyMaterial{get;set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertCompanyMaterialData"/>.
        /// </summary>
        public InsertCompanyMaterialData()
        {
        }
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial;set => this.companyMaterial = value;}
    }
}
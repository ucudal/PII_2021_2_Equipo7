namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class SelectCompanyMaterialData
    {
       private Qualification qualification;
       private CompanyMaterial companyMaterial;

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public SelectCompanyMaterialData()
        {
        }
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Qualification Qualification { get => this.qualification;set => this.qualification = value;}
       
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial;set => this.companyMaterial = value;}

    }
}
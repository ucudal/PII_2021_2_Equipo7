namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class SelectCompanyMaterialData : ActivityData
    {
        private Qualification qualification;
        private CompanyMaterial companyMaterial;
        private MaterialCategory materialCategory;
        private CompanyMaterialStock companyMaterialStock;

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

       /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
       public MaterialCategory MaterialCategory{ get => this.materialCategory;set => this.materialCategory = value;}

       /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
       public CompanyMaterialStock CompanyMaterialStock{ get => this.companyMaterialStock;set => this.companyMaterialStock = value;}
    
    }
}
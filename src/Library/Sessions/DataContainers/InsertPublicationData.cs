namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class InsertPublicationData
    {
        private CompanyMaterial companyMaterial;
        private Publication publication;
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertPublicationData"/>.
        /// </summary>
        public InsertPublicationData()
        {
        }
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial;set => this.companyMaterial = value;}
        
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Publication Publication { get => this.publication;set => this.publication = value;}

    }
}
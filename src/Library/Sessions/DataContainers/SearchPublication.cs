namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class SearchPublication
    {
        private CompanyLocation location;
        private Publication publication;
        private PublicationKeyWord publicationKeyWord;
        private string keyWord;
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchPublication"/>.
        /// </summary>
        public SearchPublication()
        {
        }
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyLocation Location { get => this.location;set => this.location = value;}
        
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Publication Publication { get => this.publication;set => this.publication = value;}

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public PublicationKeyWord PublicationKeyWord { get => this.publicationKeyWord;set => this.publicationKeyWord = value;}

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public string KeyWord { get => this.keyWord;set => this.keyWord = value;}
 
    }
}
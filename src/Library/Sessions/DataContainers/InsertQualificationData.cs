namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario
    /// </summary>
    public class InsertQualificationData
    {
       private Qualification qualification;
       

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertQualificationData"/>.
        /// </summary>
        public InsertQualificationData()
        {
        }
        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Qualification Qualification { get => this.qualification;set => this.qualification = value;}
        
      
        
    }
}
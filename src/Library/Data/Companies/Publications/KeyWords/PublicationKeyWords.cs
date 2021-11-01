using System.Text.Json;
using System.Text.Json.Serialization;


namespace ClassLibrary
{
    /// <summary>
    /// Registro de asociación de palabras claves y publicación.
    /// </summary>
    public class PublicationKeyWord : IManagableData<PublicationKeyWord>
    {
        private int id;
        private bool deleted;
        private int publicationId;
        private string keyWord;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublicationKeyWord"/>.
        /// </summary>
        [JsonConstructor]
        public PublicationKeyWord()
        {
            this.id = 0;
            this.Deleted = false;
        }

        /// <inheritdoc/>
        public int Id
        { 
            get => this.id;
            set => this.id = value;
        }

        /// <inheritdoc/>
        public bool Deleted
        { 
            get => this.deleted;
            set => this.deleted = value;
        }

        /// <summary>
        /// Id de la publicacion a la
        /// que pertenece la key word.
        /// </summary>
        public int PublicationId
        { 
            get => this.publicationId;
            set => this.publicationId = value;
        }

        /// <summary>
        /// Key word asociada a la 
        /// publicacion.
        /// </summary>
        public string KeyWord
        { 
            get => this.keyWord;
            set => this.keyWord = value;
        }

        /// <inheritdoc/>
        public PublicationKeyWord Clone()
        {
            PublicationKeyWord keyWord = new PublicationKeyWord();
            keyWord.LoadFromJson(this.ConvertToJson());
            return keyWord;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            PublicationKeyWord location = JsonSerializer.Deserialize<PublicationKeyWord>(json);
            this.Id = location.Id;
            this.Deleted = location.Deleted;
            this.PublicationId = location.PublicationId;
            this.KeyWord = location.KeyWord;
        }









        
    }


}
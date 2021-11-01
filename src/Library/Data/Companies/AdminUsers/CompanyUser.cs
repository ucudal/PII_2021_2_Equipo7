using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Registro de asociacion entre
    /// compania y usuario que la 
    /// administra.
    /// </summary>
    public class CompanyUser : IManagableData<CompanyUser>
    {
        private int id;
        private bool deleted;
        private int companyId;
        private int adminUserId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CompanyUser"/>.
        /// </summary>
        [JsonConstructor]
        public CompanyUser()
        {
            this.id = 0;
            this.deleted = false;
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
        /// Id de la compania a la 
        /// cual pertenece el usuario.
        /// </summary>
        public int CompanyId
        { 
            get => this.companyId;
            set => this.companyId = value;
        }

        /// <summary>
        /// Identificador del
        /// usuario.
        /// </summary>
        public int AdminUserId
        { 
            get => this.adminUserId;
            set => this.adminUserId = value;
        }

        /// <inheritdoc/>
        public CompanyUser Clone()
        {
            CompanyUser companyUser = new CompanyUser();
            companyUser.LoadFromJson(this.ConvertToJson());
            return companyUser;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            CompanyUser companyUser = JsonSerializer.Deserialize<CompanyUser>(json);
            this.Id = companyUser.Id;
            this.Deleted = companyUser.Deleted;
            this.CompanyId = companyUser.CompanyId;
            this.AdminUserId = companyUser.AdminUserId;
        }
    }
}
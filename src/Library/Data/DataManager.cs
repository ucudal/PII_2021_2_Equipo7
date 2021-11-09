namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class DataManager
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;
        private AccountAdmin accountAdmin = Singleton<AccountAdmin>.Instance;
        private SaleAdmin saleAdmin = Singleton<SaleAdmin>.Instance;
        private QualificationAdmin qualificationAdmin = Singleton<QualificationAdmin>.Instance;
        private MaterialCategoryAdmin materialCategoryAdmin = Singleton<MaterialCategoryAdmin>.Instance;
        private CompanyLocationAdmin companyLocationAdmin = Singleton<CompanyLocationAdmin>.Instance;
        private InvitationAdmin invitationAdmin = Singleton<InvitationAdmin>.Instance;
        private EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;
        private PublicationAdmin publicationAdmin = Singleton<PublicationAdmin>.Instance;
        private PublicationKeyWordAdmin publicationKeyWordAdmin = Singleton<PublicationKeyWordAdmin>.Instance;
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;
        private CompanyMaterialStockAdmin companyMaterialStockAdmin = Singleton<CompanyMaterialStockAdmin>.Instance;
        private CompanyMaterialQualificationAdmin companyMaterialQualificationAdmin = Singleton<CompanyMaterialQualificationAdmin>.Instance;
        private CompanyUserAdmin companyUserAdmin = Singleton<CompanyUserAdmin>.Instance;

        /// <summary>
        /// Administracion de usuarios.
        /// </summary>
        public UserAdmin User { get => this.userAdmin; }

        /// <summary>
        /// Administracion de cuentas.
        /// </summary>
        public AccountAdmin Account { get => this.accountAdmin; }

        /// <summary>
        /// Administracion de ventas.
        /// </summary>
        public SaleAdmin Sale { get => this.saleAdmin; }

        /// <summary>
        /// Administracion de habilitaciones.
        /// </summary>
        public QualificationAdmin Qualification { get => this.qualificationAdmin; }

        /// <summary>
        /// Administracion de categorias de materiales.
        /// </summary>
        public MaterialCategoryAdmin MaterialCategory { get => this.materialCategoryAdmin; }

        /// <summary>
        /// Administracion de localizaciones de empresa.
        /// </summary>
        public CompanyLocationAdmin CompanyLocation { get => this.companyLocationAdmin; }

        /// <summary>
        /// Administracion de Invitaciones.
        /// </summary>
        public InvitationAdmin Invitation { get => this.invitationAdmin; }

        /// <summary>
        /// Administracion de emprendedores.
        /// </summary>
        public EntrepreneurAdmin Entrepreneur { get => this.entrepreneurAdmin; }

        /// <summary>
        /// Administracion de empresas.
        /// </summary>
        public CompanyAdmin Company { get => this.companyAdmin; }

        /// <summary>
        /// Administracion de publicaciones.
        /// </summary>
        public PublicationAdmin Publication { get => this.publicationAdmin; }

        /// <summary>
        /// Administracion de palabras clave de publicaciones.
        /// </summary>
        public PublicationKeyWordAdmin PublicationKeyWord { get => this.publicationKeyWordAdmin; }

        /// <summary>
        /// Administracion de materiales de empresas.
        /// </summary>
        public CompanyMaterialAdmin CompanyMaterial { get => this.companyMaterialAdmin; }

        /// <summary>
        /// Administracion de stock de materiales de empresas.
        /// </summary>
        public CompanyMaterialStockAdmin CompanyMaterialStock { get => this.companyMaterialStockAdmin; }

        /// <summary>
        /// Administracion de habilitaciones para materiales de empresas.
        /// </summary>
        public CompanyMaterialQualificationAdmin CompanyMaterialQualification { get => this.companyMaterialQualificationAdmin; }
        
        /// <summary>
        /// Administracion de administradores de empresa.
        /// </summary>
        public CompanyUserAdmin CompanyUser { get => this.companyUserAdmin; }
    }
}
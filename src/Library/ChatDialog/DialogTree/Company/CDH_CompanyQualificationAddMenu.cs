using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationAddMenu : ChatDialogHandlerBase
    {
        private QualificationAdmin qualificationAdmin = Singleton<QualificationAdmin>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationAddMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_add_menu")
        {
            this.parents.Add("company_qualification_list_to_add_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();

            Qualification habilitaciones = this.qualificationAdmin.FindQualificationById(int.Parse(selector.Code));
            data.Qualification=habilitaciones;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea añadir esta habilitacion al material.\n");
            builder.Append("Nombre: " + data.Qualification.Name);
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("\\volver : Listar todos los materiales que ya posee.\n");
            return builder.ToString();
        }
    }
}
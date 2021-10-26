using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationEraseDataMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationEraseDataMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_erase_data_menu")
        {
            this.parents.Add("company_qualification_confirm_to_erase_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            QualificationEraseData();
            builder.Append("La habilitacion se elimino con exito.\n");
            builder.Append("Escriba ");
            builder.Append("\\cancelar : para volver al menu de materiales .\n");
            return builder.ToString();
        }
        private void QualificationEraseData()
        {
            LISTADEHABILITACIONESDELMATERIALDELACOMPAÑIA.RemoveAll(Hacer GetQuialificationById(IDQUALIFICATION));
        }
    }
}
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationConfirmEraseMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationConfirmEraseMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_confirm_to_erase_menu")
        {
            this.parents.Add("company_qualifications_list_to_erase_menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Esta seguro que desea eliminar esta habilitacion?\n");
            builder.Append("\\confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            return builder.ToString();
        }
    }
}
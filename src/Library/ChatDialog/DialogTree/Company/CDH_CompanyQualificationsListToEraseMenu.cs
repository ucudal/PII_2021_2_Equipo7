using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationsListToEraseMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationsListToEraseMenu(ChatDialogHandlerBase next) : base(next, "company_qualifications_list_to_erase_menu")
        {
            this.parents.Add("company_qualifications_menu");
            this.route = "\\listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de habilitaciones del material.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la habilitacion que desea eliminar, \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            builder.Append(TextoToPrintQualificationsToErase());
            return builder.ToString();
        }
        private string TextoToPrintQualificationsToErase()
        {
            StringBuilder builder = new StringBuilder();
            foreach(Qualification xQual in LISTADEHABILITACIONESDELMATERIALDELAEMPRESA)
            {
                builder.Append("" + xQual.Name + " "+ xQual.Id + "\n");
            }
            return builder.ToString();
        }
    }
}
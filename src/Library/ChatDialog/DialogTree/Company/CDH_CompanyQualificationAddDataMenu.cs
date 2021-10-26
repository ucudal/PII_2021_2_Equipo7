using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationAddDataMenu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationAddDataMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_add_data_menu")
        {
            this.parents.Add("company_qualification_add_menu");
            this.route = "\\confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            AddQualificationToMaterial();
            builder.Append("Habilitacion agregada con exito.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void AddQualificationToMaterial()
        {
            Necesito traerme el id del material con el que estoy trabajando y la habilitacion que voy a agregar
            Necesito un metodo que busque la habilitacion por id
            Necesito meter la habilitacion en una lista de habilitaciones dentro de CompanyMaterial y para eso necesito saber que company es la que esta trabajando
        }
    }
}
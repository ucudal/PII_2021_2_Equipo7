using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHMaterialCategoryConfirm : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryConfirm(ChatDialogHandlerBase next) : base(next, "matcat_confir")
        {   this.parents.Add("matcat_add_name");
            this.route = null;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertMaterialCategoryData data = new InsertMaterialCategoryData();
            data.MaterialCategory.Name=selector.Code;
            DProcessData process = new DProcessData("add_MatCat", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea agregar la categoria de el material.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();

        }

    }
}
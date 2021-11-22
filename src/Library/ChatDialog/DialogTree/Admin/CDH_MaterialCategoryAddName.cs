using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHMaterialCategoryAddName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHMaterialCategoryAddName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHMaterialCategoryAddName(ChatDialogHandlerBase next) : base(next, "matcat_add_name")
        {   this.parents.Add("mat_menu");
            this.route = "/agregar";


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre de la categorria que desea agregar\n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }

    }
}
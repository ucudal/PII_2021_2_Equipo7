using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDH_Material_Regeneration_Menu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Material_Regeneration_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Material_Regeneration_Menu(ChatDialogHandlerBase next) : base(next, "Material_Regeneration_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "\\regeneracionmaterial";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu para buscar una publicación\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\palabraclave : Buscar publicación por palabra clave.\n");
            builder.Append("\\localidad : Buscar por localidad.\n");
            builder.Append("\\cartegoria : Buscar por categoria.\n");

            return builder.ToString();
        }
    }
}
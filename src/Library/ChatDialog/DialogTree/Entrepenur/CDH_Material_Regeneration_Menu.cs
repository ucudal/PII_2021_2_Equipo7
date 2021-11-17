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
            builder.Append("Menu para saber que materiales se regeneran constantemente. \n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
           // builder.Append($"{GetTextToPrintListMaterialRegeneration(selector)}\n");
            builder.Append("\\volver : Volver al menú principal.\n");
            return builder.ToString();
        }
        /*public string GetTextToPrintListMaterialRegeneration(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;

        }*/

    }
}
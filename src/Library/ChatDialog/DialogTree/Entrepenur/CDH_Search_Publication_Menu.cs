// -----------------------------------------------------------------------
// <copyright file="CDH_Confirmation_Sale_KeyWord.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDH_Search_Publication_Menu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_Publication_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_Publication_Menu(ChatDialogHandlerBase next) : base(next, "Search_Publication_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "\\buscarpublicacion";
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
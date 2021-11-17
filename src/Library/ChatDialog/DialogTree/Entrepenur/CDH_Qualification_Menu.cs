// -----------------------------------------------------------------------
// <copyright file="CDH_Qualification_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Menu de habilitaciones.
    /// </summary>
    public class CDH_Qualification_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualification_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualification_Menu(ChatDialogHandlerBase next)
        : base(next, "Qualification_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "/habilitaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            builder.Append("Menu de habilitaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\eliminar : Listar todas las habilitaciones para eliminar una de ellas.\n");
            builder.Append("\\agregar : Agregar una habilitacion\n");
            builder.Append("\\listar : Listar las habilitaciones\n");
            builder.Append("\\volver : Volver al menu de emprendedor .\n");
            return builder.ToString();
        }
    }
}
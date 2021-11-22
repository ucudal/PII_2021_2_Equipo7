// -----------------------------------------------------------------------
// <copyright file="CDHQualificationsAddNameMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHQualificationsAddNameMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationsAddNameMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationsAddNameMenu(ChatDialogHandlerBase next)
        : base(next, "hab_add_name")
        {
            this.Parents.Add("hab_menu");
            this.Route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el nombre de la habilitacion\n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
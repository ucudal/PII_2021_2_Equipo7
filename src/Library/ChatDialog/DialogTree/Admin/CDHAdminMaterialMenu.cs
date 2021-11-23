// -----------------------------------------------------------------------
// <copyright file="CDHAdminMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHAdminMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHAdminMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminMaterialMenu(ChatDialogHandlerBase next)
        : base(next, "mat_menu")
        {
            this.Parents.Add("welcome_sysadmin");
            this.Route = "/materiales";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcion invitar .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\agregar : Invitacion de administradores del sistema.\n");
            builder.Append("\\listar : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\cancelar : Invitacion de companias al sistema.");
            return builder.ToString();
        }
    }
}
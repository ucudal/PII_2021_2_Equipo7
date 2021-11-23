// -----------------------------------------------------------------------
// <copyright file="CDHAdminInviteMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHAdminInviteMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHAdminInviteMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHAdminInviteMenu(ChatDialogHandlerBase next)
        : base(next, "invitemenu")
        {
            this.Parents.Add("welcome_sysadmin");
            this.Route = "/invitar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted ha seleccionado la opcion invitar .\n");
            builder.Append("Que tipio de invitacion quiere crear:\n\n");
            builder.Append("\\admin : Invitacion de administradores del sistema.\n");
            builder.Append("\\emprendedor : Invitacion de emprendedores al sistema.\n");
            builder.Append("\\compania_nueva : Invitacion de companias al sistema.\n");
            builder.Append("\\compania_existente \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
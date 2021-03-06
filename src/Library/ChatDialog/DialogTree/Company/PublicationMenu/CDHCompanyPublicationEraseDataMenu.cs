// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationEraseDataMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationEraseDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationEraseDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationEraseDataMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_erase_data_menu")
        {
            this.Parents.Add("company_publication_confirmation_erase_menu");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            ErasePublicationData data = process.GetData<ErasePublicationData>();
            data.RunTask();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("La publicacion se elimino con exito.\n");
            builder.Append("/volver - Para volver a la lista de publicaciones.\n");
            return builder.ToString();
        }
    }
}
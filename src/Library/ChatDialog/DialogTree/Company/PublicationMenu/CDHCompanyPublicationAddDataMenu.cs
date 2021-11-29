// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationAddDataMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyPublicationAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationAddDataMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_add_data_menu")
        {
            this.Parents.Add("company_publication_confirmation_add_menu");
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
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.CompanyId = session.EntityId;
            data.RunTask();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("La publicacion se agrego satisfactoriamente.\n");
            builder.Append("/volver - Volver al menu de publicaciones.\n");
            return builder.ToString();
        }
    }
}
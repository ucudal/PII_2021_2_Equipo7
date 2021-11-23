// -----------------------------------------------------------------------
// <copyright file="CDHQualificationAddConfirmation.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de la plataforma.
    /// </summary>
    public class CDHQualificationAddConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationAddConfirmation"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationAddConfirmation(ChatDialogHandlerBase next)
        : base(next, "hab_confir")
        {
            this.Parents.Add("hab_add_name");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            InsertQualificationData data = new InsertQualificationData();
            data.Qualification.Name = selector.Code;
            UserActivity process = new UserActivity("add_Qualification", null, this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea agregar la habilitacion.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDHQualificationAddCreate.cs" company="Universidad Católica del Uruguay">
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
    public class CDHQualificationAddCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationAddCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationAddCreate(ChatDialogHandlerBase next)
        : base(next, "hab_create")
        {
            this.Parents.Add("hab_confir");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            this.QualificationAdd(selector);
            builder.Append("La habilitacion se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }

        private void QualificationAdd(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertQualificationData data = process.GetData<InsertQualificationData>();
            Qualification qualification = data.Qualification;
            this.DatMgr.Qualification.Insert(qualification);
        }
    }
}
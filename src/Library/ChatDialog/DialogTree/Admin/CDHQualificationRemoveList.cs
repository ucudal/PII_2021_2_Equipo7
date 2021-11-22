// -----------------------------------------------------------------------
// <copyright file="CDHQualificationRemoveList.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHQualificationRemoveList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationRemoveList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationRemoveList(ChatDialogHandlerBase next)
        : base(next, "hab_remove_conf")
        {
            this.Parents.Add("hab_remove");
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
            data.Qualification=this.DatMgr.Qualification.GetById(int.Parse(selector.Code));
            UserActivity process = new UserActivity("Remove_Qualification", null, this.Code, data);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.CurrentActivity = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea eliminar la habilitacion.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
    }
}
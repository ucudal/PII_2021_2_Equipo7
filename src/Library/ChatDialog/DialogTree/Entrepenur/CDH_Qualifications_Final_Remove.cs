// -----------------------------------------------------------------------
// <copyright file="CDH_Qualifications_Final_Remove.cs" company="Universidad Católica del Uruguay">
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
    public class CDH_Qualifications_Final_Remove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Final_Remove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Final_Remove(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Final_Remove")
        {
            this.Parents.Add("Qualifications_Confirmation_Remove");
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
            EntrepreneurQualificationDeleteData deleteData = session.CurrentActivity.GetData<EntrepreneurQualificationDeleteData>();
            deleteData.RunTask();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("La habilitacion se elimino con exito.\n");
            builder.Append("/volver - Regresar al listado de habilitaciones.");
            return builder.ToString();
        }
    }
}
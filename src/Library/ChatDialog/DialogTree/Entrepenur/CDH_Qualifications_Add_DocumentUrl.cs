// -----------------------------------------------------------------------
// <copyright file="CDHQualificationsAddDocumentUrl.cs" company="Universidad Católica del Uruguay">
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
    /// Confirmación de añadir habilitación.
    /// </summary>
    public class CDHQualificationsAddDocumentUrl : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationsAddDocumentUrl"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationsAddDocumentUrl(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Add_DocUrl")
        {
            this.Parents.Add("Qualifications_Add_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
            EntrepreneurQualificationInsertData data = new EntrepreneurQualificationInsertData(id, session.EntityId);
            UserActivity activity = new UserActivity("entrepreneur_qualification_insert", "Qualification_Menu", "/agregar", data);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingrese una url donde se pueda ubicar el documento que verifica la habilitacion.\n");
            builder.AppendLine("[url] - Continuar.\n");
            builder.Append("/volver - Volver al menu de habilitaciones.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        Qualification qualification = this.DatMgr.Qualification.GetById(id);
                        if (qualification is not null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
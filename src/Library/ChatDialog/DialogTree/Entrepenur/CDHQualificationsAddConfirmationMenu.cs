// -----------------------------------------------------------------------
// <copyright file="CDHQualificationsAddConfirmationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHQualificationsAddConfirmationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationsAddConfirmationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationsAddConfirmationMenu(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Add_Confirmation_Menu")
        {
            this.Parents.Add("Qualifications_Add_DocUrl");
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
            UserActivity activity = session.CurrentActivity;
            EntrepreneurQualificationInsertData data = activity.GetData<EntrepreneurQualificationInsertData>();

            data.DocumentUri = new Uri(selector.Code, UriKind.Absolute);

            session.CurrentActivity = activity;

            Qualification qual = this.DatMgr.Qualification.GetById(data.QualificationId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingresara una habilitacion a su emprendimiento con los siguientes datos.\n");
            builder.AppendLine($"<b>Habilitacion</b>: {qual.Name}");
            builder.AppendLine($"<b>Documento</b>: {data.DocumentUri}\n");
            builder.AppendLine("/confirmar - Confirmar la adicion.\n");
            builder.Append("/volver - Cancelar la adicion.");
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
                    return Uri.TryCreate(selector.Code, UriKind.Absolute, out _);
                }
            }

            return false;
        }
    }
}
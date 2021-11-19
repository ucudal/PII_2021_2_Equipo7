// -----------------------------------------------------------------------
// <copyright file="CDH_Qualifications_Confirmation_Remove.cs" company="Universidad Católica del Uruguay">
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
    /// Confirmar.
    /// </summary>
    public class CDH_Qualifications_Confirmation_Remove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Confirmation_Remove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Confirmation_Remove(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Confirmation_Remove")
        {
            this.Parents.Add("Qualifications_Remove_Menu");
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
            EntrepreneurQualificationDeleteData deleteData = new EntrepreneurQualificationDeleteData(id);
            UserActivity activity = new UserActivity("entrepreneur_qualification_delete", "Qualification_Menu", "/eliminar", deleteData);
            session.PushActivity(activity);

            EntrepreneurQualification entreQual = this.DatMgr.EntrepreneurQualification.GetById(id);
            Qualification qual = this.DatMgr.Qualification.GetById(entreQual.QualificationId);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Esta seguro que desea eliminar la habilitacion <b>{qual.Name}</b>?\n");
            builder.AppendLine("/confirmar - Confirmar eliminacion.");
            builder.AppendLine("/volver - Volver al menu de habilitaciones.");
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
                        EntrepreneurQualification qualification = this.DatMgr.EntrepreneurQualification.GetById(id);
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
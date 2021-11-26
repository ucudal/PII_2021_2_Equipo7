// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationConfirmEraseMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyQualificationConfirmEraseMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationConfirmEraseMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationConfirmEraseMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualification_confirm_to_erase_menu")
        {
            this.Parents.Add("company_qualifications_list_to_erase_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            SelectCompanyMaterialQualificationData data = activity.GetData<SelectCompanyMaterialQualificationData>();
            data.CompanyMaterialQualification = this.DatMgr.CompanyMaterialQualification.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));

            builder.Append("Esta seguro que desea eliminar la habilitacion con el nombre " + this.DatMgr.CompanyMaterial.GetById(data.CompanyMaterialQualification.CompanyMatId).Name + " ?\n ");
            builder.Append("Esta seguro que desea eliminar la habilitacion con el nombre ?\n");
            builder.Append("/confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("/cancelar : Volver al menu de materiales .\n");
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
                    Qualification qualification = this.DatMgr.Qualification.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (qualification is not null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
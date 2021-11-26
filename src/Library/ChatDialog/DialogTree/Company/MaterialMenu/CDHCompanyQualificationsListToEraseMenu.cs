// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationsListToEraseMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyQualificationsListToEraseMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationsListToEraseMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationsListToEraseMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualifications_list_to_erase_menu")
        {
            this.Parents.Add("company_qualifications_menu");
            this.Route = "/eliminar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity;

            //Comparar con CDHListCategoryMenu.cs. No entiendo como hago para guardarme el mat y despues la habilitacion
            if (session.CurrentActivity.Code != "search_by_page_company_qualifications_to_erase_results")
            {
                //IReadOnlyCollection<int> qualificationsToErase = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(data.CompanyMaterial.Id);
                //activity = new UserActivity("search_by_page_company_qualifications_to_erase_results", "company_actions_material_menu", "/habilitaciones", data);
                //session.PushActivity(activity);
            }

            activity = session.CurrentActivity;
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de habilitaciones del material.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la habilitacion que desea eliminar, \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("/cancelar : Volver al menu de materiales .\n");
            builder.Append(this.TextoToPrintQualificationsToErase(data));
            return builder.ToString();
        }

        private string TextoToPrintQualificationsToErase(SelectCompanyMaterialData search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(paramName: nameof(search));
            }

            StringBuilder builder = new StringBuilder();
            foreach (int xQualiId in search.PageItems)
            {
                Qualification xQualification = this.DatMgr.Qualification.GetById(xQualiId);
                builder.AppendLine($"{xQualification.Id} - {xQualification.Name}");
            }

            return builder.ToString();
        }
    }
}
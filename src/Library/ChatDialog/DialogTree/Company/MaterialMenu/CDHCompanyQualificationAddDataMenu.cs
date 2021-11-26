// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationAddDataMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyQualificationAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationAddDataMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualification_add_data_menu")
        {
            this.Parents.Add("company_qualification_add_confirmation_menu");
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
            UserActivity activity = session.CurrentActivity;
            InsertCompanyMaterialData data = activity.GetData<InsertCompanyMaterialData>();

            StringBuilder builder = new StringBuilder();
            this.AddQualificationToMaterial(selector);
            builder.Append("Habilitacion agregada con exito.\n");
            builder.Append("escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            data.RunTask();
            session.CurrentActivity.Terminate(chainInitiator: false);
            return builder.ToString();
        }

        private void AddQualificationToMaterial(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            CompanyMaterialQualification xHabiMat = this.DatMgr.CompanyMaterialQualification.New();
            xHabiMat.QualificationId = data.Qualification.Id;
            xHabiMat.CompanyMatId = data.CompanyMaterial.Id;
            this.DatMgr.CompanyMaterialQualification.Insert(xHabiMat);
            session.CurrentActivity = activity;
        }
    }
}
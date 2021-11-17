// -----------------------------------------------------------------------
// <copyright file="CDH_Qualifications_Final_Add_Menu.cs" company="Universidad Católica del Uruguay">
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
    public class CDH_Qualifications_Final_Add_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Final_Add_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Final_Add_Menu(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Final_Add_Menu")
        {
            this.Parents.Add("Qualifications_Add_Confirmation_Menu");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            this.AddQualificationToMaterial(selector);
            builder.Append("Habilitacion agregada con exito.\n");
            builder.Append("Escriba \n");
            builder.Append("\\volver : para retornar al menu de materiales.\n");
            return builder.ToString();
        }

        private void AddQualificationToMaterial(ChatDialogSelector selector)
        {
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            EntrepreneurQualification habi = this.DatMgr.EntrepreneurQualification.New();
            habi.QualificationId = data.Qualification.Id;
            habi.EntrepreneurId = data.Qualification.Id;
            this.DatMgr.EntrepreneurQualification.Insert(habi);
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_Confirmation_Sale_KeyWord.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Confirmar
    /// </summary>
    public class CDH_Qualifications_Confirmation_Remove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Confirmation_Remove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Confirmation_Remove(ChatDialogHandlerBase next) : base(next, "Qualifications_Confirmation_Remove")
        {
            this.Parents.Add("Qualifications_Remove_Menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            EntrepreneurQualification data = process.GetData<EntrepreneurQualification>();
            data=this.DatMgr.EntrepreneurQualification.GetById(int.Parse(selector.Code));

            builder.Append($"Esta seguro que desea eliminar la habilitacion con el id {this.DatMgr.EntrepreneurQualification.GetById(session.UserId)} ?\n ");
            builder.Append("\\confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    Qualification qualification = this.DatMgr.Qualification.GetById(int.Parse(selector.Code));
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
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_Qualifications_Confirmation_Remove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Confirmation_Remove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Confirmation_Remove(ChatDialogHandlerBase next) : base(next, "Qualifications_Confirmation_Remove")
        {
            this.parents.Add("Qualifications_Remove_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            EntrepreneurQualification data = process.GetData<EntrepreneurQualification>();
            data=this.datMgr.EntrepreneurQualification.GetById(int.Parse(selector.Code));

            builder.Append($"Esta seguro que desea eliminar la habilitacion con el id {this.datMgr.EntrepreneurQualification.GetById(session.UserId)} ?\n ");
            builder.Append("\\confirmar : Confirmar en caso de que este seguro.\n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            return builder.ToString();
        }
        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    Qualification qualification = this.datMgr.Qualification.GetById(int.Parse(selector.Code));
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
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
        public CDH_Qualifications_Final_Remove(ChatDialogHandlerBase next) : base(next, "Qualifications_Final_Remove")
        {
            this.parents.Add("Qualifications_Confirmation_Remove");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            QualificationEraseData(selector);
            builder.Append("La habilitacion se elimino con exito.\n");
            builder.Append("Escriba ");
            builder.Append("\\cancelar : para volver al menu de materiales .\n");
            return builder.ToString();
        }
        
        private void QualificationEraseData(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            EntrepreneurQualification data = process.GetData<EntrepreneurQualification>();
            EntrepreneurQualification Habi=this.datMgr.EntrepreneurQualification.GetById(session.UserId);
            Habi.Deleted=true;
            this.datMgr.EntrepreneurQualification.Update(Habi);            
        }
    }
}
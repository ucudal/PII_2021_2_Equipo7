using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_QualificationAddCreate : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_QualificationAddCreate"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_QualificationAddCreate(ChatDialogHandlerBase next) : base(next, "hab_create")
        {
            this.parents.Add("hab_confir");
            this.route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            QualificationAdd(selector);
            builder.Append("La habilitacion se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("\\volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }
        
        private void QualificationAdd(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            InsertQualificationData data = process.GetData<InsertQualificationData>();
            Qualification qualification=data.Qualification;
            this.datMgr.Qualification.Insert(qualification);
        }
    }
}
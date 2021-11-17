using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CHD_QualificationRemoveList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CHD_QualificationRemoveList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CHD_QualificationRemoveList(ChatDialogHandlerBase next) : base(next, "hab_remove_conf")
        {
            this.parents.Add("hab_remove");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertQualificationData data = new InsertQualificationData();
            data.Qualification=this.datMgr.Qualification.GetById(int.Parse(selector.Code));
            DProcessData process = new DProcessData("Remove_Qualification", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea eliminar la habilitacion.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();
        }
        
       
    }
}
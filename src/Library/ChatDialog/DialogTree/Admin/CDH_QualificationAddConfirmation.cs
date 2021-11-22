using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de la plataforma.
    /// </summary>
    public class CDHQualificationAddConfirmation : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHWelcomeSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationAddConfirmation(ChatDialogHandlerBase next) : base(next, "hab_confir")
        {   this.parents.Add("hab_add_name");
            this.route = null;


        }
        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            InsertQualificationData data = new InsertQualificationData();
            data.Qualification.Name=selector.Code;
            DProcessData process = new DProcessData("add_Qualification", this.code, data);
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            session.Process = process;
            StringBuilder builder = new StringBuilder();

            builder.Append("Desea agregar la habilitacion.\n");
            builder.Append("\\confirmar \n");
            builder.Append("\\cancelar");
            return builder.ToString();

        }

    }
}
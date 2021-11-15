using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_Qualifications_Remove_Menu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Remove_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Remove_Menu(ChatDialogHandlerBase next) : base(next, "Qualifications_Remove_Menu")
        {
            this.Parents.Add("Qualification_Menu");
            this.Route = "/eliminar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Lista de habilitaciones\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("Ingrese el numero de la habilitacion que desea eliminar, \n");
            builder.Append(" en caso contrario escriba \n");
            builder.Append("\\cancelar : Volver al menu de materiales .\n");
            builder.Append(TextoToPrintQualificationsToErase(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }
        private string TextoToPrintQualificationsToErase(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            IReadOnlyCollection<int> Habilitacion=this.DatMgr.EntrepreneurQualification.GetQualificationsForEntrepreneur(session.UserId);
            foreach(int i in Habilitacion)
            {
                EntrepreneurQualification Habili=this.DatMgr.EntrepreneurQualification.GetById(Habilitacion.ElementAt(i));
                builder.Append($" Nombre de la habilitación {this.DatMgr.Qualification.GetById(Habili.EntrepreneurId).Name} de id {this.DatMgr.Qualification.GetById(Habili.EntrepreneurId).Id} \n");

            }
            return builder.ToString();
        }
    }
}
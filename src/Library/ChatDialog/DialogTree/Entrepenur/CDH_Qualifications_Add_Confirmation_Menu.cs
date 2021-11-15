using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_Qualifications_Add_Confirmation_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Add_Confirmation_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Add_Confirmation_Menu(ChatDialogHandlerBase next) : base(next, "Qualifications_Add_Confirmation_Menu")
        {
            this.parents.Add("Qualifications_Add_Menu");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            Qualification habilitaciones = this.datMgr.Qualification.GetById(int.Parse(selector.Code));
            data.Qualification=habilitaciones;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea añadir esta habilitacion al material.\n");
            builder.Append("Nombre: " + habilitaciones.Name);
            builder.Append("\\confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("\\volver : Listar todos los materiales que ya posee.\n");
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
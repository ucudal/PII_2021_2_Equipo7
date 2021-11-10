using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso de un codigo de invitacion
    /// no valido o ya utilizado. Se vuelve a pedir
    /// al usuario que ingrese otro codigo o se le da
    /// la opcion de cancelar el proceso.
    /// </summary>
    public class CDH_SignUpBadCode : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpBadCode"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpBadCode(ChatDialogHandlerBase next) : base(next, "registration_bad_invite")
        {
            this.parents.Add("registration_invite");
            this.route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            Session session = sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SignUpData data = process.GetData<SignUpData>();
            data.Type = RegistrationType.CompanyJoin;
            session.MenuLocation = "registration_invite";
            
            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion no es valido. Pruebe ingresar otro.\n\n");
            builder.Append("/cancelar - Abandonar el proceso de registro.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (this.parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('\\'))
                {
                    Invitation invite = this.datMgr.Invitation.GetByCode(selector.Code);
                    if (invite is null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpUserFirstName.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al la verificacion de codigo de
    /// invitacion por el usuario. Comienza el proceso
    /// de ingreso de datos pidiendo en primer lugar
    /// el primer nombre del usuario.
    /// </summary>
    public class CDHSignUpUserFirstName : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpUserFirstName"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpUserFirstName"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpUserFirstName(ChatDialogHandlerBase next)
            : base(next, "registration_user_f_name")
        {
            this.Parents.Add("registration_invite_comp_new");
            this.Parents.Add("registration_invite_comp_join");
            this.Parents.Add("registration_invite_entre_new");
            this.Parents.Add("registration_invite_sysadmin_join");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Preciso algunos datos para registrarlo. Ingrese su <b>primer nombre</b>.");
            return builder.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpCancel.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al ingreso del comando de cancelar
    /// mientras se esta en uno de los pasos pertenecientes
    /// al proceso de registro de usuarios. Devuelve al
    /// usuario al menu de bienvenida.
    /// </summary>
    public class CDH_SignUpCancel : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpCancel"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpCancel"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpCancel(ChatDialogHandlerBase next)
            : base(next, "registration_cancel")
        {
            this.Parents.Add("registration_invite");
            this.Parents.Add("registration_invite_comp_join");
            this.Parents.Add("registration_invite_comp_new");
            this.Parents.Add("registration_invite_entre_new");
            this.Parents.Add("registration_invite_sysadmin_join");
            this.Parents.Add("registration_user_f_name");
            this.Parents.Add("registration_user_l_name");
            this.Parents.Add("registration_new_comp_name");
            this.Parents.Add("registration_new_comp_trade");
            this.Parents.Add("registration_new_comp_verify");
            this.Parents.Add("registration_new_sysadmin_verify");
            this.Parents.Add("Sign_Review_Join_Company");
            this.Parents.Add("registration_new_entre_name");
            this.Parents.Add("registration_new_entre_trade");
            this.Parents.Add("registration_join_sysadmin_verify");
            this.Parents.Add("registration_new_entre_verify");

            this.Route = "/cancelar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ha cancelado el proceso de registro. Gracias por visitar.");
            return builder.ToString();
        }
    }
}
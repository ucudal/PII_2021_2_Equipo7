// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpBadCode.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
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
    public class CDHSignUpBadCode : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpBadCode"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpBadCode"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpBadCode(ChatDialogHandlerBase next)
            : base(next, "registration_bad_invite")
        {
            this.Parents.Add("registration_invite");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity activity = session.CurrentActivity;

            session.CurrentActivity = activity;
            session.MenuLocation = "registration_invite";

            StringBuilder builder = new StringBuilder();
            builder.Append("Su codigo de invitacion no es valido. Pruebe ingresar otro.\n\n");
            builder.Append("/cancelar - Abandonar el proceso de registro.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    Invitation invite = this.DatMgr.Invitation.GetByCode(selector.Code);
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
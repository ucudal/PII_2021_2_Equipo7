// -----------------------------------------------------------------------
// <copyright file="CDHSignUpReviewSysAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del apellido del
    /// usuario cuando el registro es para un nuevo
    /// administrador de la plataforma. Le pide al
    /// usuario revisar los datos ingresados y confirmar
    /// el ingreso al sistema.
    /// </summary>
    public class CDHSignUpReviewSysAdmin : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDHSignUpReviewSysAdmin"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDHSignUpReviewSysAdmin"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHSignUpReviewSysAdmin(ChatDialogHandlerBase next)
            : base(next, "registration_join_sysadmin_verify")
        {
            this.Parents.Add("registration_user_l_name");
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
            SignUpDataSysAdminJoin data = activity.GetData<SignUpDataSysAdminJoin>();

            User user = data.User;
            user.LastName = selector.Code.Trim();

            session.CurrentActivity = activity;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Antes de completar el proceso de registro, por favor verifique los datos ingresados.\n");
            builder.AppendLine($"<b>1er Nombre</b>: {user.FirstName}");
            builder.AppendLine($"<b>1er Apellido</b>: {user.LastName}\n");
            builder.AppendLine("/confirmar - Completar el registro.");
            builder.Append("/cancelar - Abandonar el registro.");
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
                    Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                    if (typeof(SignUpData).IsAssignableFrom(session.CurrentActivity.TypeOfData))
                    {
                        SignUpData data = session.CurrentActivity.GetData() as SignUpData;
                        if (data.Type == RegistrationType.SystemAdminJoin)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
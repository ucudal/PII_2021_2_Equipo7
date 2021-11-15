// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpDoneJoinCompany.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la confirmacion de los datos
    /// ingresados en el registro de un usiario
    /// a una compañía ya existente. Ingresa los
    /// datos al sistema.
    /// </summary>
    public class CDH_SignUpDoneJoinCompany : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpDoneJoinCompany"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpDoneJoinCompany"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpDoneJoinCompany(ChatDialogHandlerBase next)
            : base(next, "registration_Done_join_Company")
        {
            this.Parents.Add("Sign_Review_Join_Company");
            this.Route = "/confirmar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();

            User user = this.DatMgr.User.New();
            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Role = UserRole.CompanyAdministrator;
            int userId = this.DatMgr.User.Insert(user);

            if (userId != 0)
            {
                Account acc = this.DatMgr.Account.New();
                acc.UserId = userId;
                acc.Service = selector.Service;
                acc.CodeInService = selector.Account;
                this.DatMgr.Account.Insert(acc);

                Invitation inv = this.DatMgr.Invitation.GetByCode(data.InviteCode);

                if (inv.CompanyId != 0)
                {
                    CompanyUser compUsr = this.DatMgr.CompanyUser.New();
                    compUsr.CompanyId = inv.CompanyId;
                    compUsr.AdminUserId = userId;
                    this.DatMgr.CompanyUser.Insert(compUsr);
                }

                inv.Used = true;
                this.DatMgr.Invitation.Update(inv);
            }

            session.MenuLocation = null;
            session.Process = null;

            StringBuilder builder = new StringBuilder();
            builder.Append("Gracias registrarse en nuestra plataforma.\n\n");
            builder.Append("/inicio - Menu de inicio del usuario.");
            return builder.ToString();
        }
    }
}
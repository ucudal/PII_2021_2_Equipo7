//-----------------------------------------------------------------------------------
// <copyright file="SignUpDataSysAdminJoin.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class SignUpDataSysAdminJoin : SignUpData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpDataSysAdminJoin"/> class.
        /// </summary>
        /// <param name="account">
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </param>
        public SignUpDataSysAdminJoin(string account, MessagingService service)
            : base(account, service)
        {
        }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            User user = this.DatMgr.User.New();
            user.FirstName = this.User.FirstName;
            user.LastName = this.User.LastName;
            user.Role = UserRole.SystemAdministrator;
            int userId = this.DatMgr.User.Insert(user);

            if (userId == 0)
            {
                return false;
            }

            Account acc = this.DatMgr.Account.New();
            acc.UserId = userId;
            acc.Service = this.Service;
            acc.CodeInService = this.Account;
            int accId = this.DatMgr.Account.Insert(acc);

            if (accId == 0)
            {
                return false;
            }

            Invitation invite = this.DatMgr.Invitation.GetByCode(this.InviteCode);
            invite.Used = true;
            bool isOk = this.DatMgr.Invitation.Update(invite);

            return isOk;
        }
    }
}
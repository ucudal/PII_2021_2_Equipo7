//-----------------------------------------------------------------------------------
// <copyright file="SignUpDataCompanyJoin.cs" company="Universidad Católica del Uruguay">
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
    public class SignUpDataCompanyJoin : SignUpData
    {
        private int companyId;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpDataCompanyJoin"/> class.
        /// </summary>
        /// <param name="account">
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </param>
        public SignUpDataCompanyJoin(string account, MessagingService service)
            : base(account, service)
        {
        }

        /// <summary>
        /// Id de la empresa a la cual unirse.
        /// </summary>
        public int CompanyId { get => this.companyId; set => this.companyId = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            User user = this.DatMgr.User.New();
            user.FirstName = this.User.FirstName;
            user.LastName = this.User.LastName;
            user.Role = UserRole.CompanyAdministrator;
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

            CompanyUser compUsr = this.DatMgr.CompanyUser.New();
            compUsr.CompanyId = this.CompanyId;
            compUsr.AdminUserId = userId;
            int compUserId = this.DatMgr.CompanyUser.Insert(compUsr);

            if (compUserId == 0)
            {
                return false;
            }

            Invitation inv = this.DatMgr.Invitation.GetByCode(this.InviteCode);
            inv.Used = true;
            bool isOk = this.DatMgr.Invitation.Update(inv);

            return isOk;
        }
    }
}
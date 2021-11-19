//-----------------------------------------------------------------------------------
// <copyright file="SignUpDataCompanyNew.cs" company="Universidad Católica del Uruguay">
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
    public class SignUpDataCompanyNew : SignUpData
    {
        private Company company;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpDataCompanyNew"/> class.
        /// </summary>
        /// <param name="account">
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </param>
        public SignUpDataCompanyNew(string account, MessagingService service)
            : base(account, service)
        {
        }

        /// <summary>
        /// Instancia de <see cref="ClassLibrary.Company"/> que almacenara
        /// los datos de la empresa para registrarlos al
        /// terminar el proceso, si es requerido.
        /// </summary>
        public Company Company { get => this.company; set => this.company = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            User user = this.DatMgr.User.New();
            user.FirstName = this.User.FirstName;
            user.LastName = this.User.LastName;
            user.Role = UserRole.CompanyAdministrator;
            user.Suspended = false;
            int userId = this.DatMgr.User.Insert(user);

            if (userId == 0)
            {
                return false;
            }

            Company comp = this.DatMgr.Company.New();
            comp.Name = this.Company.Name;
            comp.Trade = this.Company.Trade;
            int compId = this.DatMgr.Company.Insert(comp);

            if (compId == 0)
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
            compUsr.CompanyId = compId;
            compUsr.AdminUserId = userId;
            int compUserId = this.DatMgr.CompanyUser.Insert(compUsr);

            if (compUserId == 0)
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
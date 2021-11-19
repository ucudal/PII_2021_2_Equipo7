//-----------------------------------------------------------------------------------
// <copyright file="SignUpDataEntrepreneurNew.cs" company="Universidad Católica del Uruguay">
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
    public class SignUpDataEntrepreneurNew : SignUpData
    {
        private Entrepreneur entrepreneur;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpDataEntrepreneurNew"/> class.
        /// </summary>
        /// <param name="account">
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </param>
        public SignUpDataEntrepreneurNew(string account, MessagingService service)
            : base(account, service)
        {
        }

        /// <summary>
        /// Instancia de <see cref="ClassLibrary.Entrepreneur"/> que almacenara
        /// los datos del emprendedor para registrarlos al
        /// terminar el proceso, si es requerido.
        /// </summary>
        public Entrepreneur Entrepreneur { get => this.entrepreneur; set => this.entrepreneur = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            User user = this.DatMgr.User.New();
            user.FirstName = this.User.FirstName;
            user.LastName = this.User.LastName;
            user.Role = UserRole.Entrepreneur;
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

            Entrepreneur entre = this.DatMgr.Entrepreneur.New();
            entre.Name = this.Entrepreneur.Name;
            entre.Trade = this.Entrepreneur.Trade;
            entre.UserId = userId;
            int entreId = this.DatMgr.Entrepreneur.Insert(entre);

            if (entreId == 0)
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
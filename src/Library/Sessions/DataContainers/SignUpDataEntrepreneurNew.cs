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
            bool isOk = true;

            int userId;
            User user = this.DatMgr.User.New();
            user.FirstName = this.User.FirstName;
            user.LastName = this.User.LastName;
            user.Role = UserRole.Entrepreneur;
            userId = this.DatMgr.User.Insert(user);
            isOk = userId != 0;

            int accId = 0;
            if (isOk)
            {
                Account acc = this.DatMgr.Account.New();
                acc.UserId = userId;
                acc.Service = this.Service;
                acc.CodeInService = this.Account;
                accId = this.DatMgr.Account.Insert(acc);
                isOk = accId != 0;
            }

            int entreId = 0;
            if (isOk)
            {
                Entrepreneur entre = this.DatMgr.Entrepreneur.New();
                entre.Name = this.Entrepreneur.Name;
                entre.Trade = this.Entrepreneur.Trade;
                entre.GeoReference = this.Entrepreneur.GeoReference;
                entre.UserId = userId;
                entreId = this.DatMgr.Entrepreneur.Insert(entre);
                isOk = entreId != 0;
            }

            if (isOk)
            {
                Invitation invite = this.DatMgr.Invitation.GetByCode(this.InviteCode);
                invite.Used = true;
                isOk = this.DatMgr.Invitation.Update(invite);
            }

            if (!isOk)
            {
                this.CancelTask(userId: userId, accId: accId, entreId: entreId);
            }

            return isOk;
        }

        /// <summary>
        /// Deshace los cambios realizados en caso de error
        /// al correr la tarea del Data.
        /// </summary>
        /// <param name="userId">
        /// Id del usuario.
        /// </param>
        /// <param name="accId">
        /// Id de la cuenta.
        /// </param>
        /// <param name="entreId">
        /// Id del emprendedor.
        /// </param>
        private void CancelTask(int userId = 0, int accId = 0, int entreId = 0)
        {
            if (userId != 0)
            {
                this.DatMgr.User.Delete(userId);
            }

            if (accId != 0)
            {
                this.DatMgr.Account.Delete(accId);
            }

            if (entreId != 0)
            {
                this.DatMgr.Entrepreneur.Delete(entreId);
            }
        }
    }
}
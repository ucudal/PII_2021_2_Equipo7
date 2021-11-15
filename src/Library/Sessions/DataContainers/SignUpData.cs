//-----------------------------------------------------------------------------------
// <copyright file="SignUpData.cs" company="Universidad Católica del Uruguay">
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
    public class SignUpData
    {
        private readonly string account;
        private readonly MessagingService service;
        private RegistrationType type;
        private string inviteCode;
        private User user;
        private Company company;
        private Entrepreneur entrepreneur;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpData"/> class.
        /// </summary>
        /// <param name="account">
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </param>
        public SignUpData(string account, MessagingService service)
        {
            this.account = account;
            this.service = service;
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public string Account { get => this.account; }

        /// <summary>
        /// Servicio de mensajeria utilizado
        /// por el usuario a registrar.
        /// </summary>
        public MessagingService Service { get => this.service; }

        /// <summary>
        /// Tipo de registro que se va a procesar.
        /// </summary>
        public RegistrationType Type { get => this.type; set => this.type = value; }

        /// <summary>
        /// Codigo de invitacion utilizado por el
        /// usuario para registrarse.
        /// </summary>
        public string InviteCode { get => this.inviteCode; set => this.inviteCode = value; }

        /// <summary>
        /// Instancia de <see cref="ClassLibrary.User"/> que almacenara
        /// los datos de usuario para registrarlos al
        /// terminar el proceso.
        /// </summary>
        public User User { get => this.user; set => this.user = value; }

        /// <summary>
        /// Instancia de <see cref="ClassLibrary.Company"/> que almacenara
        /// los datos de la empresa para registrarlos al
        /// terminar el proceso, si es requerido.
        /// </summary>
        public Company Company { get => this.company; set => this.company = value; }

        /// <summary>
        /// Instancia de <see cref="ClassLibrary.Entrepreneur"/> que almacenara
        /// los datos del emprendedor para registrarlos al
        /// terminar el proceso, si es requerido.
        /// </summary>
        public Entrepreneur Entrepreneur { get => this.entrepreneur; set => this.entrepreneur = value; }
    }
}
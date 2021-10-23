namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de un mensaje.
    /// Tiene los datos del servicio de mensajeria
    /// la cuenta del emisor, el usuario local, su
    /// estado, y el mensaje en si.
    /// </summary>
    public class MessageWrapper
    {
        private string message;
        private MessagingService service;
        private string account;
        private int userId;
        private UserStatus userStatus;

        /// <summary>
        /// Crea un contenedor de mensaje con la
        /// cuenta remota y el mensaje recibido.
        /// </summary>
        /// <param name="message">
        /// Texto del mensaje recibido.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria desde el que se
        /// recibe el mensaje.
        /// </param>
        /// <param name="account">
        /// Cuenta remota en el servicio de mensajeria
        /// que envio el mensaje.
        /// </param>
        public MessageWrapper(string message, MessagingService service, string account)
        {
            this.message = message;
            this.service = service;
            this.account = account;
        }

        /// <summary>
        /// Texto del mensaje recibido.
        /// </summary>
        /// <value><c>string</c></value>
        public string Message
        {
            get => this.message;
            set => this.message = value;
        }

        /// <summary>
        /// Servicio de mensajeria desde el que se
        /// recibe el mensaje.
        /// </summary>
        /// <value><c>MessagingService</c></value>
        public MessagingService Service 
        {
            get => this.service;
            set => this.service = value;
        }

        /// <summary>
        /// Cuenta remota en el servicio de mensajeria
        /// que envio el mensaje.
        /// </summary>
        /// <value><c>string</c></value>
        public string Account
        {
            get => this.account;
            set => this.account = value;
        }

        /// <summary>
        /// Identificador del usuario dentro
        /// de la plataforma.
        /// </summary>
        /// <value><c>int</c></value>
        public int UserId 
        {
            get => this.userId;
            set => this.userId = value;
        }

        /// <summary>
        /// Estado del usuario dentro de la
        /// plataforma.
        /// </summary>
        /// <value><c>UserStatus</c></value>
        public UserStatus UserStatus 
        {
            get => this.userStatus;
            set => this.userStatus = value;
        }
    }
}
namespace Library
{
    /// <summary>
    /// Contenedor de la respuesta.
    /// Contiene el mensaje de respuesta al
    /// usuario, y los datos de la cuenta 
    /// remota para saber a donde enviar el mensaje.
    /// </summary>
    public class ResponseWrapper
    {
        private string message;
        private MessagingService service;
        private string account;

        /// <summary>
        /// Crea un contenedor de respuesta.
        /// </summary>
        /// <param name="message">
        /// Texto del mensaje a enviar.
        /// </param>
        /// <param name="service">
        /// Servicio de mensajeria hacia el que se
        /// debe enviar el mensaje.
        /// </param>
        /// <param name="account">
        /// Cuenta remota en el servicio de mensajeria
        /// al que se debe enviar el mensaje.
        /// </param>
        public ResponseWrapper(string message, MessagingService service, string account)
        {
            this.message = message;
            this.service = service;
            this.account = account;
        }

        /// <summary>
        /// Texto del mensaje a enviar.
        /// </summary>
        /// <value><c>string</c></value>
        public string Message
        {
            get => this.message;
            set => this.message = value;
        }

        /// <summary>
        /// Servicio de mensajeria hacia el que se
        /// debe enviar el mensaje.
        /// </summary>
        /// <value><c>MessagingService</c></value>
        public MessagingService Service 
        {
            get => this.service;
            set => this.service = value;
        }

        /// <summary>
        /// Cuenta remota en el servicio de mensajeria
        /// al que se debe enviar el mensaje.
        /// </summary>
        /// <value><c>string</c></value>
        public string Account
        {
            get => this.account;
            set => this.account = value;
        }
    }
}
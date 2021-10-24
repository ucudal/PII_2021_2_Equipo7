namespace ClassLibrary
{
    /// <summary>
    /// Selector para la cadena de responsabilidad 
    /// usada en el dialogo de chat con el Bot.
    /// </summary>
    public class ChatDialogSelector
    {
        private string context;
        private string code;
        private string account;
        private MessagingService service;
        private string[] args;

        /// <summary>
        /// Crea un nuevo selector.
        /// </summary>
        /// <param name="message">
        /// Contenedor del mensaje del usuario recibido.
        /// </param>
        /// <param name="context">
        /// Localizacion actual en el arbol de dialogos
        /// del usuario.
        /// </param>
        /// <param name="args">
        /// Argumentos (no utilizado).
        /// </param>
        public ChatDialogSelector(MessageWrapper message, string context, string[] args)
        {
            this.code = message.Message;
            this.account = message.Account;
            this.service = message.Service;
            this.context = context;
            this.args = args;
        }

        /// <summary>
        /// Localizacion actual en el arbol de dialogos
        /// del usuario.
        /// </summary>
        public string Context { get => this.context; }

        /// <summary>
        /// Argumentos (no utilizado).
        /// </summary>
        public string[] Args { get => this.args; }

        /// <summary>
        /// Codigo ingresado por el usuario en el mensaje
        /// recibido.
        /// </summary>
        public string Code
        {
            get => this.code;
            set => this.code = value;
        }

        /// <summary>
        /// Cuenta en el servicio de mensajeria del
        /// usuario que envio el mensaje
        /// </summary>
        public string Account { get => this.account; }

        /// <summary>
        /// Servicio de mensajeria desde el que
        /// se recibio el mensaje del usuario.
        /// </summary>
        public MessagingService Service { get => this.service; }
    }
}
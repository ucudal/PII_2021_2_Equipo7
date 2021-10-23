namespace Library
{
    /// <summary>
    /// Encargada de recibir el mensaje y procesar
    /// el comando de acuerdo a la sesion del usuario.
    /// </summary>
    public class CommandHandler
    {
        private SessionsContainer sessions = Singleton<SessionsContainer>.Instance;
        private DiscussionEntry discussionEntry = Singleton<DiscussionEntry>.Instance;
        
        /// <summary>
        /// Procesa el comando enviado por el usuario
        /// de acuerdo a su sesion y lo envia el punto de
        /// entrada de la cadena de comandos.
        /// </summary>
        /// <param name="message">
        /// Contenedor del mensaje enviado por el usuario.
        /// </param>
        /// <returns>Texto del mensaje de respuesta.</returns>
        public string HandleMessage(MessageWrapper message)
        {
            Session session = this.sessions.CreateSession(message.Service, message.Account);
            session.UserId = message.UserId;
            string context;
            if (message.UserStatus == UserStatus.Suspended)
            {
                context = null;
                message.Message = "\\suspendeduser";
            }
            else
            {
                if (session is null)
                {
                    context = null;
                    switch (message.UserStatus)
                    {
                        case UserStatus.Unregistered:
                            message.Message = "\\registration";
                            break;

                        case UserStatus.Registered:
                        default:
                            message.Message = "\\welcome";
                            break;
                    }
                }
                else
                {
                    context = session.MenuLocation;
                    if (context is null)
                    {
                        switch (message.UserStatus)
                        {
                            case UserStatus.Unregistered:
                                message.Message = "\\registration";
                                break;

                            case UserStatus.Registered:
                            default:
                                message.Message = "\\welcome";
                                break;
                        }
                    }
                }
            }
            DiscussionSelector selector = new DiscussionSelector(message, context, null);

            return this.discussionEntry.Start(selector);
        }
    }
}
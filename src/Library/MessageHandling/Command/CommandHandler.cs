namespace ClassLibrary
{
    /// <summary>
    /// Encargada de recibir el mensaje y procesar
    /// el comando de acuerdo a la sesion del usuario.
    /// </summary>
    public class CommandHandler
    {
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
            SessionsContainer sessions = Singleton<SessionsContainer>.Instance;
            ChatDialogEntry chatEntry = new ChatDialogEntry();
            DataManager dataManager = new DataManager();

            Session session = sessions.CreateSession(message.Service, message.Account);
            
            if (message.UserStatus == UserStatus.Registered)
            {
                User user = dataManager.User.GetById(message.UserId);
                session.UserId = user.Id;
                switch (user.Role)
                {
                    case UserRole.CompanyAdministrator:
                        int companyId = dataManager.CompanyUser.GetCompanyForUser(message.UserId);
                        session.EntityId = companyId;
                        break;
                    case UserRole.Entrepreneur:
                        Entrepreneur entrepreneur = dataManager.Entrepreneur.GetByUser(message.UserId);
                        session.EntityId = entrepreneur.Id;
                        break;
                    default:
                        session.EntityId = 0;
                        break;
                }
            }

            string context;
            if (message.UserStatus == UserStatus.Suspended)
            {
                context = null;
                message.Message = "/suspendeduser";
            }
            else
            {
                if (session is null)
                {
                    context = null;
                    switch (message.UserStatus)
                    {
                        case UserStatus.Unregistered:
                            message.Message = "/registration";
                            break;

                        case UserStatus.Registered:
                        default:
                            message.Message = "/welcome";
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
                                message.Message = "/registration";
                                break;

                            case UserStatus.Registered:
                            default:
                                message.Message = "/welcome";
                                break;
                        }
                    }
                    else
                    {
                        if (context == "session_expired")
                        {
                            message.Message = "/resetsession";
                        }
                    }
                }
            }
            ChatDialogSelector selector = new ChatDialogSelector(message, context, null);

            return chatEntry.Start(selector);
        }
    }
}
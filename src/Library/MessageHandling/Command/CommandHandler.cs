namespace ClassLibrary
{
    /// <summary>
    /// Encargada de recibir el mensaje y procesar
    /// el comando de acuerdo a la sesion del usuario.
    /// </summary>
    public class CommandHandler
    {
        private SessionsContainer sessions = Singleton<SessionsContainer>.Instance;
        private ChatDialogEntry chatEntry = Singleton<ChatDialogEntry>.Instance;
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;
        private CompanyUserAdmin companyUserAdmin = Singleton<CompanyUserAdmin>.Instance;
        private EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;
        
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
            if (message.UserStatus == UserStatus.Registered)
            {
                User user = this.userAdmin.GetById(message.UserId);
                session.UserId = user.Id;
                switch (user.Role)
                {
                    case UserRole.CompanyAdministrator:
                        int companyId = companyUserAdmin.GetCompanyForUser(message.UserId);
                        session.EntityId = companyId;
                        break;
                    case UserRole.Entrepreneur:
                        Entrepreneur entrepreneur = entrepreneurAdmin.GetByUser(message.UserId);
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
            ChatDialogSelector selector = new ChatDialogSelector(message, context, null);

            return this.chatEntry.Start(selector);
        }
    }
}
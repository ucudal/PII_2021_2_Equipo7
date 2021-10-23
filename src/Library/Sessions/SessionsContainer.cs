using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de sesiones. Almacena una lista
    /// de sesiones activas y permite crearlas/modificarlas.
    /// </summary>
    public class SessionsContainer
    {
        private List<Session> sessions = new List<Session>();
        private int sessionTimeoutMinutes = 5;

        /// <summary>
        /// Crea una nueva sesion si esta no existe y la retorna.
        /// Si la sesion ya existe, carga esa y la retorna.
        /// </summary>
        /// <param name="service">
        /// Servicio de mensajeria de la sesion relevante.
        /// </param>
        /// <param name="account">
        /// Identificador en el servicio de mensajeria 
        /// de la sesion relevante.
        /// </param>
        /// <returns><c>Session</c></returns>
        public Session CreateSession(MessagingService service, string account)
        {
            Session session = this.GetSession(service, account);
            if (session is null)
            {
                session = new Session(service, account, null);
                item.LastActivity = DateTime.Now;
                sessions.Add(session);
            }
            return session;
        }

        /// <summary>
        /// Carga una sesion del contenedor si esta existe.
        /// Ademas, chequea que esta no haya expirado. En
        /// caso de que si haya expirado, cambia el contexto
        /// para que la discusion siguiente lo refleje.
        /// </summary>
        /// <param name="service">
        /// Servicio de mensajeria de la sesion relevante.
        /// </param>
        /// <param name="account">
        /// Identificador en el servicio de mensajeria 
        /// de la sesion relevante.
        /// </param>
        /// <returns><c>Session</c></returns>
        public Session GetSession(MessagingService service, string account)
        {
            Session item = sessions.Find(session => session.Account == account && session.Service == service);
            if (item is not null)
            {
                double secondsSinceLastActivity = (DateTime.Now - item.LastActivity).TotalSeconds;
                if (secondsSinceLastActivity / 60.0 >= this.sessionTimeoutMinutes)
                {
                    item.MenuLocation = "session_expired";
                }
                item.LastActivity = DateTime.Now;
            }
            return item;
        }
    }
}
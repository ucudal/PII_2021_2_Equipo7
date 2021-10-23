using System;
using System.Collections.Generic;

namespace Library
{
    public class SessionsContainer
    {
        private List<Session> sessions = new List<Session>();
        private int sessionTimeoutMinutes = 5;

        public Session CreateSession(MessagingService service, string account)
        {
            Session session = this.GetSession(service, account);
            if (session is null)
            {
                session = new Session(service, account, null);
                sessions.Add(session);
            }
            return session;
        }

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
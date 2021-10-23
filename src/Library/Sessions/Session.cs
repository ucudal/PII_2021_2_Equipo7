using System;

namespace Library
{
    public class Session
    {
        private MessagingService service;
        private string account;
        private int userId;
        private string menuLocation;
        private DProcessData process;
        private DateTime lastActivity;

        public Session(MessagingService service, string account, string menuLocation)
        {
            this.service = service;
            this.account = account;
            this.menuLocation = menuLocation;
            this.lastActivity = DateTime.Now;
        }

        public MessagingService Service { get => this.service; }
        public string Account { get => this.account; }
        public string MenuLocation
        {
            get => this.menuLocation;
            set 
            {
                this.menuLocation = value;
                this.lastActivity = DateTime.Now;
            }
        }
        public DateTime LastActivity
        {
            get => this.lastActivity;
            set => this.lastActivity = value;
        }
        public DProcessData Process
        {
            get => this.process;
            set 
            {
                this.process = value;
                this.lastActivity = DateTime.Now;
            }
        }

        public int UserId 
        { 
            get => this.userId;
            set => this.userId = value; 
        }
    }
}
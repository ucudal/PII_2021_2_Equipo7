using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase que contiene los datos de una sesion de usuario.
    /// </summary>
    public class Session
    {
        private MessagingService service;
        private string account;
        private int userId;
        private int entityId;
        private UserRole userRole;
        private string menuLocation;
        private DProcessData process;
        private DateTime lastActivity;
        private Stack<DProcessData> processStack;

        /// <summary>
        /// Crea una instancia de Session a partir de una
        /// cuenta en un servicio de mensajeria y la posicion
        /// En el arbol de discusiones con el Bot.
        /// </summary>
        /// <param name="service">
        /// Servicio de mensajeria.
        /// </param>
        /// <param name="account">
        /// Identificador del usuario en el servicio de mensajeria.
        /// </param>
        /// <param name="menuLocation">
        /// Posicion actual del usuario en el arbol de discusiones
        /// con el Bot.
        /// </param>
        public Session(MessagingService service, string account, string menuLocation)
        {
            this.service = service;
            this.account = account;
            this.menuLocation = menuLocation;
            this.lastActivity = DateTime.Now;
            this.processStack = new Stack<DProcessData>();
        }

        /// <summary>
        /// Servicio de mensajeria.
        /// </summary>
        /// <value><c>MessagingService</c></value>
        public MessagingService Service { get => this.service; }
        
        /// <summary>
        /// Identificador en el servicio de mensajeria.
        /// </summary>
        public string Account { get => this.account; }

        /// <summary>
        /// Localizacion del usuario en el arbol de discusiones.
        /// </summary>
        public string MenuLocation
        {
            get => this.menuLocation;
            set 
            {
                this.menuLocation = value;
                this.lastActivity = DateTime.Now;
            }
        }

        /// <summary>
        /// Ultimo momento de actividad del usuario.
        /// </summary>
        public DateTime LastActivity
        {
            get => this.lastActivity;
            set => this.lastActivity = value;
        }

        /// <summary>
        /// Datos del proceso actual si hay uno activo.
        /// </summary>
        public DProcessData Process
        {
            get => this.process;
            set 
            {
                this.process = value;
                this.lastActivity = DateTime.Now;
            }
        }

        /// <summary>
        /// Id del usuario en la plataforma
        /// </summary>
        public int UserId 
        { 
            get => this.userId;
            set => this.userId = value; 
        }

        /// <summary>
        /// Id de empresa o emprendedor asociado al usuario.
        /// </summary>
        public int EntityId 
        { 
            get => this.entityId; 
            set => this.entityId = value; 
        }

        /// <summary>
        /// Empuja un nuevo proceso al stack de procesos.
        /// </summary>
        /// <param name="process">
        /// Proceso a añadir.
        /// </param>
        public void PushProcess(DProcessData process)
        {
            processStack.Push(process);
        }

        /// <summary>
        /// Saca un proceso del stack de procesos
        /// </summary>
        /// <returns>
        /// Proceso al tope de la lista.
        /// </returns>
        public DProcessData PopProcess()
        {
            DProcessData data;
            if (processStack.TryPop(out data))
            {
                return data;
            }
            return null;
        }

        /// <summary>
        /// Obtiene una copia del ultimo proceso
        /// en el stack de procesos.
        /// </summary>
        /// <returns>
        /// Copia del proceso al tope del stack.
        /// </returns>
        public DProcessData CloneCurrentProcess()
        {
            DProcessData data;
            if (processStack.TryPeek(out data))
            {
                return data;
            }
            return null;
        }

        /// <summary>
        /// Remplaza el ultimo proceso del stack.
        /// </summary>
        /// <param name="process">
        /// Proceso que va a remplazar al ultimo.
        /// </param>
        public void ReplaceProcessInStack(DProcessData process)
        {
            DProcessData data;
            processStack.TryPop(out data);
            processStack.Push(process);
        }
    }
}
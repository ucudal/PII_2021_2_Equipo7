//-----------------------------------------------------------------------------------
// <copyright file="Session.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

using System;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
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
        }

        /// <summary>
        /// Servicio de mensajeria.
        /// </summary>
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
        /// Id del usuario en la plataforma.
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
        /// Rol del usuario de la sesion.
        /// </summary>
        public UserRole UserRole
        {
            get => this.userRole;
            set => this.userRole = value;
        }
    }
}
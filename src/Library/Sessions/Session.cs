//-----------------------------------------------------------------------------------
// <copyright file="Session.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

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
        private Stack<UserActivity> activities;
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
            this.activities = new Stack<UserActivity>();
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

        /// <summary>
        /// Ultima actividad en el stack.
        /// </summary>
        public UserActivity CurrentActivity
        {
            get
            {
                if (this.activities.TryPeek(out UserActivity data))
                {
                    return data;
                }

                return null;
            }

            set
            {
                this.activities.TryPop(out _);
                this.activities.Push(value);
            }
        }

        /// <summary>
        /// Empuja una nueva actividad al stack de actividades.
        /// </summary>
        /// <param name="activity">
        /// Actividad a añadir.
        /// </param>
        public void PushActivity(UserActivity activity)
        {
            this.activities.Push(activity);
        }

        /// <summary>
        /// Saca una actividad del stack de
        /// actividades.
        /// </summary>
        /// <returns>
        /// Actividad al tope de la lista.
        /// </returns>
        public UserActivity PopActivity()
        {
            if (this.activities.TryPop(out UserActivity data))
            {
                return data;
            }

            return null;
        }

        /// <summary>
        /// Limpia el stack de actividades.
        /// </summary>
        public void ClearActivitiesStack()
        {
            this.activities.Clear();
        }

        /// <summary>
        /// Revisa si existen actividades en el stack.
        /// </summary>
        /// <returns>
        /// Confirmacion de existencia de actividades.
        /// </returns>
        public bool StackHasActivities()
        {
            return this.activities.Count != 0;
        }
    }
}
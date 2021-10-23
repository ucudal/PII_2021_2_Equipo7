using System;
using System.Collections.Generic;
using System.Collections;

namespace ClassLibrary
{
    /// <summary>
    /// la clase account maneja las cuentas de lso usuarios
    /// </summary>
    public class Account
    {
    /// <summary>
    /// Servicio de mensajeria
    /// </summary>
    /// <value></value>
        public MessagingService Service {get;set;}
        /// <summary>
        /// id de el usuario dado por el servicio de mensajeria
        /// </summary>
        /// <value></value>
        public string Id {get;set;}
        /// <summary>
        /// constructor de Account
        /// </summary>
        /// <param name="service">Servicio de mensajeria </param>
        /// <param name="id">id de la cuenta del servicio de mensajeria</param>
        public Account(MessagingService service, string id)
        {
            this.Service=service;
            this.Id=id;
        }
    }
}
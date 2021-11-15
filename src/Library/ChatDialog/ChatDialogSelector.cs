// -----------------------------------------------------------------------
// <copyright file="ChatDialogSelector.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Selector para la cadena de responsabilidad
    /// usada en el dialogo de chat con el Bot.
    /// </summary>
    public class ChatDialogSelector
    {
        private string context;
        private string code;
        private string account;
        private MessagingService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatDialogSelector"/> class.
        /// Crea un nuevo selector.
        /// </summary>
        /// <param name="message">
        /// Contenedor del mensaje del usuario recibido.
        /// </param>
        /// <param name="context">
        /// Localizacion actual en el arbol de dialogos
        /// del usuario.
        /// </param>
        public ChatDialogSelector(MessageWrapper message, string context)
        {
            if (message is null)
            {
                throw new ArgumentNullException(paramName: nameof(message));
            }

            this.code = message.Message;
            this.account = message.Account;
            this.service = message.Service;
            this.context = context;
        }

        /// <summary>
        /// Localizacion actual en el arbol de dialogos
        /// del usuario.
        /// </summary>
        public string Context { get => this.context; }

        /// <summary>
        /// Codigo ingresado por el usuario en el mensaje
        /// recibido.
        /// </summary>
        public string Code
        {
            get => this.code;
            set => this.code = value;
        }

        /// <summary>
        /// Cuenta en el servicio de mensajeria del
        /// usuario que envio el mensaje.
        /// </summary>
        public string Account { get => this.account; }

        /// <summary>
        /// Servicio de mensajeria desde el que
        /// se recibio el mensaje del usuario.
        /// </summary>
        public MessagingService Service { get => this.service; }
    }
}
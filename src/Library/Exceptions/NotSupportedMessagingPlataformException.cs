// -----------------------------------------------------------------------
// <copyright file="NotSupportedMessagingPlataformException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Excepcion al intentar utilizar una plataforma de mensajeria no admitida.
    /// </summary>
    public class NotSupportedMessagingPlataformException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedMessagingPlataformException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        public NotSupportedMessagingPlataformException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedMessagingPlataformException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="message">
        /// Mensaje de la excepcion.
        /// </param>
        public NotSupportedMessagingPlataformException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedMessagingPlataformException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="message">
        /// Mensaje de la excepcion.
        /// </param>
        /// <param name="innerException">
        /// Excepcion interna.
        /// </param>
        public NotSupportedMessagingPlataformException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedMessagingPlataformException"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="info">
        /// Informacion de serializacion(?).
        /// </param>
        /// <param name="context">
        /// Contexto de flujo(?).</param>
        protected NotSupportedMessagingPlataformException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
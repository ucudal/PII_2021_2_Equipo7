using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class NotSupportedMessagingPlataformException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        public NotSupportedMessagingPlataformException()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="message"></param>
        public NotSupportedMessagingPlataformException(string message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NotSupportedMessagingPlataformException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotSupportedMessagingPlataformException"/>.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NotSupportedMessagingPlataformException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
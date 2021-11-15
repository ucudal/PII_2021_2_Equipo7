// -----------------------------------------------------------------------
// <copyright file="MessagingService.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Enumerable que lista los distintos
    /// servicios de mensajeria soportados
    /// por el Bot.
    /// </summary>
    public enum MessagingService
    {
        /// <summary>
        /// No definido.
        /// </summary>
        Undefined,

        /// <summary>
        /// Canal de comunicacion por la consola.
        /// </summary>
        Console,

        /// <summary>
        /// Canal de comunicacion por Telegram.
        /// </summary>
        Telegram,
    }
}
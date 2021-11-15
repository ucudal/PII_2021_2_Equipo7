// -----------------------------------------------------------------------
// <copyright file="UserStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Enumerable que lista los estados generales
    /// de un usuario al conectarse a la plataforma.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// No definido.
        /// </summary>
        Undefined,

        /// <summary>
        /// Usuario registrado.
        /// </summary>
        Registered,

        /// <summary>
        /// Usuario no registrado.
        /// </summary>
        Unregistered,

        /// <summary>
        /// Usuario suspendido.
        /// </summary>
        Suspended,
    }
}
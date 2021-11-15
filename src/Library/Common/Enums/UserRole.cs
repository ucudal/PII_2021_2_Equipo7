// -----------------------------------------------------------------------
// <copyright file="UserRole.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Enumerable que lista los roles
    /// a los que pueden pertenecer los
    /// usuarios.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// No definido.
        /// </summary>
        Undefined,

        /// <summary>
        /// Administrador del sistema.
        /// </summary>
        SystemAdministrator,

        /// <summary>
        /// Administrador de empresa.
        /// </summary>
        CompanyAdministrator,

        /// <summary>
        /// Emprendedor.
        /// </summary>
        Entrepreneur,
    }
}
// -----------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Clase que permite reutilizar la misma instancia
    /// de otra clase por todo el programa.
    /// </summary>
    /// <typeparam name="T">
    /// Clase de la cual se precisa utilizar la misma
    /// instancia.
    /// </typeparam>
    public static class Singleton<T>
        where T : new()
    {
        private static T instance;

        /// <summary>
        /// Instancia compartida de la clase <c>T</c>.
        /// </summary>
        /// <returns>
        /// Singleton/Instancia de la clase <c>T</c>.
        /// </returns>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}
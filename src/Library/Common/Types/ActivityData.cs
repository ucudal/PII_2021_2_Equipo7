// -----------------------------------------------------------------------
// <copyright file="ActivityData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de datos para una actividad.
    /// Tambien expone una tarea a realizar con los
    /// datos.
    /// </summary>
    public abstract class ActivityData
    {
        private bool taskResult = true;

        /// <summary>
        /// Accion asociada a la actividad y sus datos.
        /// </summary>
        /// <returns>
        /// Accion completada exitosamente o no.
        /// </returns>
        public virtual bool RunTask()
        {
            return this.taskResult;
        }
    }
}
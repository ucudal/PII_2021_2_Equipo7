// -----------------------------------------------------------------------
// <copyright file="QualificationAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para la administración de las habilitaciones.
    /// </summary>
    public sealed class QualificationAdmin : DataAdmin<Qualification>
    {
        /// <inheritdoc/>
        protected override void ValidateData(Qualification item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(paramName: nameof(item));
            }

            if (item.Name is null || item.Name.Length == 0)
            {
                throw new ValidationException("Requerido nombre.");
            }
        }
    }
}
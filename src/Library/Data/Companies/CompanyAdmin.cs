// -----------------------------------------------------------------------
// <copyright file="CompanyAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// clase administradora de company.
    /// </summary>
    public sealed class CompanyAdmin : DataAdmin<Company>
    {
        /// <summary>
        /// Obtiene una compania por
        /// su nombre.
        /// </summary>
        /// <param name="name">
        /// Nombre por el cual buscar.
        /// </param>
        /// <returns>
        /// Compania encontrada.
        /// </returns>
        public Company GetByName(string name)
        {
            IReadOnlyCollection<Company> companies = this.Items;
            foreach (Company comp in companies)
            {
                if (comp.Name == name)
                {
                    return comp.Clone();
                }
            }

            return null;
        }

        /// <inheritdoc/>
        protected override void ValidateData(Company item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(paramName: nameof(item));
            }

            if (item.Trade is null || item.Trade.Length == 0)
            {
                throw new ValidationException("Requerido oficio.");
            }

            if (item.Name is null || item.Name.Length == 0)
            {
                throw new ValidationException("Requerido nombre.");
            }
        }
    }
}
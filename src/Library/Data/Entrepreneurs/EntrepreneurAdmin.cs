// -----------------------------------------------------------------------
// <copyright file="EntrepreneurAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Entrepreneur.
    /// </summary>
    public sealed class EntrepreneurAdmin : DataAdmin<Entrepreneur>
    {
        /// <summary>
        /// encontramos un emprendedor por id de user.
        /// </summary>
        /// <param name="id">id de user.</param>
        /// <returns>Emprendedor del usuario.</returns>
        public Entrepreneur GetByUser(int id)
        {
            IReadOnlyCollection<Entrepreneur> entrepreneurs = this.Items;
            foreach (Entrepreneur item in entrepreneurs)
            {
                if (item.UserId == id)
                {
                    return item.Clone();
                }
            }

            return null;
        }

        /// <summary>
        /// encontramos un emprendedor por nombre.
        /// </summary>
        /// <param name="name">nombre del emprendedor.</param>
        /// <returns>Emprendedor por nombre.</returns>
        public Entrepreneur GetByName(string name)
        {
            IReadOnlyCollection<Entrepreneur> entrepreneurs = this.Items;
            foreach (Entrepreneur comp in entrepreneurs)
            {
                if (comp.Name == name)
                {
                    return comp.Clone();
                }
            }

            return null;
        }

        /// <inheritdoc/>
        protected override void ValidateData(Entrepreneur item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // DataManager dataManager = new DataManager();
            if (item.GeoReference is null || item.GeoReference.Length == 0)
            {
                throw new ValidationException("Requerida geo referencia.");
            }

            if (item.Name is null || item.Name.Length == 0)
            {
                throw new ValidationException("Requerido nombre.");
            }

            if (item.Trade is null || item.Trade.Length == 0)
            {
                throw new ValidationException("Requerido oficio del emprendedor.");
            }

            if (item.UserId == 0/* || !dataManager.User.Exists(item.UserId)*/)
            {
                throw new ValidationException("Requerido id del usuario.");
            }
        }
    }
}

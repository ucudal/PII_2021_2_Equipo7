// -----------------------------------------------------------------------
// <copyright file="InsertCompanyLocationData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertCompanyLocationData : ActivityData
    {
        private CompanyLocation compLoc;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertCompanyLocationData"/>.
        /// </summary>
        public InsertCompanyLocationData()
            : base()
        {
        }

        /// <summary>
        /// Objeto con la localizacion a agregar.
        /// </summary>
        public CompanyLocation CompLoc
        {
            get => this.compLoc;
            set => this.compLoc = value;
        }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            DataManager dataManager = new DataManager();

            CompanyLocation loc = dataManager.CompanyLocation.New();
            loc.CompanyId = this.compLoc.CompanyId;
            loc.GeoReference = this.compLoc.GeoReference;
            int id = dataManager.CompanyLocation.Insert(loc);

            return id != 0;
        }
    }
}
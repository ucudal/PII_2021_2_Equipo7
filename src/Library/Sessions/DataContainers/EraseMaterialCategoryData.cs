// -----------------------------------------------------------------------
// <copyright file="EraseMaterialCategoryData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class EraseMaterialCategoryData : ActivityData
    {
        private int matCatId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertMaterialCategoryData"/>.
        /// </summary>
        public EraseMaterialCategoryData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public int MatCatId { get => this.matCatId; set => this.matCatId = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            DataManager datMgr = new DataManager();

            return datMgr.MaterialCategory.Delete(this.matCatId);
        }
    }
}
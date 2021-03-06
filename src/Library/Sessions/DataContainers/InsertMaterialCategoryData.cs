// -----------------------------------------------------------------------
// <copyright file="InsertMaterialCategoryData.cs" company="Universidad Católica del Uruguay">
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
    public class InsertMaterialCategoryData : ActivityData
    {
        private MaterialCategory materialCategory;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertMaterialCategoryData"/>.
        /// </summary>
        public InsertMaterialCategoryData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public MaterialCategory MaterialCategory { get => this.materialCategory; set => this.materialCategory = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            DataManager datMgr = new DataManager();

            MaterialCategory matCat = datMgr.MaterialCategory.New();
            matCat.Name = this.materialCategory.Name;
            int matCatId = datMgr.MaterialCategory.Insert(matCat);

            return matCatId != 0;
        }
    }
}
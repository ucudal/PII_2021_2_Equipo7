using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public sealed class CompanyMaterialAdmin : DataAdmin<CompanyMaterial>
    {
        /// <summary>
        /// Obtiene un listado de materiales de
        /// empresa filtrados por su empresa.
        /// </summary>
        /// <param name="companyId">
        /// Id de la empresa por la cual
        /// filtrar la lista.
        /// </param>
        /// <returns>
        /// Listado de Ids de materiales
        /// de empresa pertenecientes a
        /// la empresa dada.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInCompany(int companyId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.CompanyId == companyId)
                {
                    resultList.Add(mat.Id);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene un listado de materiales de
        /// empresa filtrados por su empresa.
        /// </summary>
        /// <param name="companyId">
        /// Id de la empresa por la cual
        /// filtrar la lista.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por hoja.
        /// </param>
        /// <param name="page">
        /// Hoja la cual recuperar.
        /// </param>
        /// <returns>
        /// Listado de Ids de materiales
        /// de empresa pertenecientes a
        /// la empresa dada.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInCompany(int companyId, int itemCount, int page)
        {
            List<CompanyMaterial> resultList = new List<CompanyMaterial>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.CompanyId == companyId)
                {
                    resultList.Add(mat);
                }
            }

            List<CompanyMaterial> companyMatsPage = this.GetItemPage(resultList, itemCount, page);
            return companyMatsPage.Select(mat => mat.Id).ToList().AsReadOnly();
        }

        /// <summary>
        /// Obtiene un listado de materiales
        /// de compania filtrado por una dada
        /// categoria de materiales.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania dentro de la
        /// cual se buscaran los materiales.
        /// </param>
        /// <param name="materialCatId">
        /// Id de la categoria por la cual
        /// filtrar los materiales.
        /// </param>
        /// <returns>
        /// Listado de Ids de todos los materiales
        /// de la empresa que pertenecen a la
        /// categoria dada.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInCompanyForCategory(int companyId, int materialCatId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.CompanyId == companyId && mat.MaterialCategoryId == materialCatId)
                {
                    resultList.Add(mat.Id);
                }
            }

            return resultList.AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene un listado de materiales
        /// de compania filtrado por una dada
        /// categoria de materiales.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania dentro de la
        /// cual se buscaran los materiales.
        /// </param>
        /// <param name="materialCatId">
        /// Id de la categoria por la cual
        /// filtrar los materiales.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por hoja.
        /// </param>
        /// <param name="page">
        /// Hoja la cual recuperar.
        /// </param>
        /// <returns>
        /// Listado de Ids de todos los materiales
        /// de la empresa que pertenecen a la
        /// categoria dada.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInCompanyForCategory(int companyId, int materialCatId, int itemCount, int page)
        {
            List<CompanyMaterial> resultList = new List<CompanyMaterial>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.CompanyId == companyId && mat.MaterialCategoryId == materialCatId)
                {
                    resultList.Add(mat);
                }
            }

            List<CompanyMaterial> companyMatsPage = this.GetItemPage(resultList, itemCount, page);
            return companyMatsPage.Select(mat => mat.Id).ToList().AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene un listado de materiales
        /// de empresas filtrado por su 
        /// categoria de materiales.
        /// </summary>
        /// <param name="materialCatId">
        /// Id de la categoria de materiales
        /// por la cual filtrar.
        /// </param>
        /// <returns>
        /// Listado de Ids de todos los
        /// materiales de empresas que
        /// cumplen con el filtro de
        /// categoria.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsForCategory(int materialCatId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.MaterialCategoryId == materialCatId)
                {
                    resultList.Add(mat.Id);
                }
            }

            return resultList.AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene un listado de materiales
        /// de empresas filtrado por su 
        /// categoria de materiales.
        /// </summary>
        /// <param name="materialCatId">
        /// Id de la categoria de materiales
        /// por la cual filtrar.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por hoja.
        /// </param>
        /// <param name="page">
        /// Hoja la cual recuperar.
        /// </param>
        /// <returns>
        /// Listado de Ids de todos los
        /// materiales de empresas que
        /// cumplen con el filtro de
        /// categoria.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsForCategory(int materialCatId, int itemCount, int page)
        {
            List<CompanyMaterial> resultList = new List<CompanyMaterial>();
            IReadOnlyCollection<CompanyMaterial> companyMats = this.Items;
            foreach (CompanyMaterial mat in companyMats)
            {
                if (mat.MaterialCategoryId == materialCatId)
                {
                    resultList.Add(mat);
                }
            }

            List<CompanyMaterial> companyMatsPage = this.GetItemPage(resultList, itemCount, page);
            return companyMatsPage.Select(mat => mat.Id).ToList().AsReadOnly();
        }

        /// <inheritdoc/>
        protected override void ValidateData(CompanyMaterial item)
        {
            DataManager dataManager = new DataManager();
            if(item.CompanyId == 0/* || !dataManager.Company.Exists(item.CompanyId)*/) 
                throw new ValidationException("Requerida compania.");
            if(item.MaterialCategoryId == 0/* || !dataManager.MaterialCategory.Exists(item.MaterialCategoryId)*/) 
                throw new ValidationException("Requerida categoria del material.");
            if(item.Name is null || item.Name.Length == 0) 
                throw new ValidationException("Requerido nombre.");
        }
    }
}
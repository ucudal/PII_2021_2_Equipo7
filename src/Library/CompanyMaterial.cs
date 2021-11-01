using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa material empresa.
    /// </summary>
    public class CompanyMaterial : IManagableData<CompanyMaterial>
    {
        //private static List<CompanyMaterial> companyMaterials = new List<CompanyMaterial>(); 

        /// <summary>
        /// Identificador de cada materialEmpresa
        /// </summary>
        /// <value>Almacenamos un numero el cual va a identificar cada materialEmpresa. Este numero se saca de la lista de materialesEmpresa</value>
        public int Id{get; set;}
        
        /// <summary>
        /// Nombre del materialEmpresa
        /// </summary>
        /// <value>Almacenamos el nombre del materialEmpresa en un string</value>
        public string Name{get;set;}

        /// <summary>
        ///Ultimo re-stock
        /// </summary>
        /// <value>Almacenamos la ultima fecha que se hizo un re-stock del materialEmpresa</value>
        public DateTime LastRestock{get;set;}

        /// <summary>
        ///Dias entre re-stock de cada materialEmpresa
        /// </summary>
        /// <value>Almacenamos el numero de dias que demora el re-stock del materialEmpresa. Esto nos sirve para poder decirle al emprendedor cada cuanto se genera este materialEmpresa</value>
        public int DateBetweenRestocks{get;set;}
        
        /// <summary>
        /// Obtiene un valor que indica si el materiaEmpresa fue eliminado
        /// </summary>
        /// <value><c>true</c> si el materialEmpresa fue eliminado, <c>false</c> en caso contrario.</value>
        public bool Deleted{get;set;}

        /// <summary>
        ///La categoria donde se guarda el materialEmpresa
        /// </summary>
        /// <value>Almacenamos en que categoria esta situado el materialEmpresa</value>
        public int MaterialCategoryId { get; set; }

        /// <summary>
        /// Id de la empresa a la cual pertenece el material de empresa.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Constructor de la clase con parametros.
        /// </summary>
        public CompanyMaterial(int id, string name, DateTime lastRestock, int dateBetweenRestocks, int materialCategoryId, int companyId)
        {
            this.Id=id;
            this.Name=name;
            this.LastRestock=lastRestock;
            this.DateBetweenRestocks=dateBetweenRestocks;
            this.Deleted=false;
            this.MaterialCategoryId=materialCategoryId;
            this.CompanyId=companyId;
        }

        /// <summary>
        /// Constructor de la clase vacio.
        /// </summary>
        public CompanyMaterial()
        {
            this.Id = 0;
            this.Deleted = false;
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            CompanyMaterial companyMaterial=JsonSerializer.Deserialize<CompanyMaterial>(json);
            this.Id=companyMaterial.Id;
            this.Name=companyMaterial.Name;
            this.LastRestock=companyMaterial.LastRestock;
            this.DateBetweenRestocks=companyMaterial.DateBetweenRestocks;
            this.Deleted=companyMaterial.Deleted;
            this.MaterialCategoryId = companyMaterial.MaterialCategoryId;
            this.CompanyId = companyMaterial.CompanyId;
        }

        /// <inheritdoc/>    
        public CompanyMaterial Clone()
        {
            CompanyMaterial companyMaterial=new CompanyMaterial();
            companyMaterial.LoadFromJson(this.ConvertToJson());
            return companyMaterial;
        }
    
        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
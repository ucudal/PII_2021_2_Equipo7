using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa material empresa.
    /// </summary>
    public class CompanyMaterial
    {
        //private static List<CompanyMaterial> companyMaterials = new List<CompanyMaterial>(); 

        /// <summary>
        /// Identificador de cada materialEmpresa
        /// </summary>
        /// <value>Almacenamos un numero el cual va a identificar cada materialEmpresa. Este numero se saca de la lista de materialesEmpresa</value>
        public int Id{get; private set;}
        
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
        public MaterialCategory MaterialCategory{get;set;}
        

        /// <summary>
        /// Obtiene una lista de habilitaciones necesarias para cada materialEmpresa.
        /// </summary>
        /// <value>Almacenamos las habilitaciones de cada materialEmpresa. Esto nos sirve para saber que habilitaciones exigirle al emprendedor para el uso/adquisicion del material</value>
        public List<Qualification> Qualifications {get;set;}

        /// <summary>
        /// Obtiene una lista del stock que hay en cada location
        /// </summary>
        /// <value>Almacenamos el stock que tiene cada empreza de un material empresa en cada locacion</value>
        public List<CompanyStock> StockPerLocations {get;set;}


        /// <summary>
        /// Constructor de la clase con parametros.
        /// </summary>
        public CompanyMaterial(int id,string name,DateTime lastRestock, int dateBetweenRestocks,MaterialCategory materialCategory)
        {
            this.Id=id;
            this.Name=name;
            this.LastRestock=lastRestock;
            this.DateBetweenRestocks=dateBetweenRestocks;
            this.Deleted=false;
            this.MaterialCategory=materialCategory;
            this.Qualifications=new List<Qualification>();
            this.StockPerLocations=new List<CompanyStock>();
        }

        /// <summary>
        /// Constructor de la clase vacio.
        /// </summary>
        public CompanyMaterial()
        {

        }

        /// <summary>
        /// Elimina el materialEmpresa.
        /// </summary>
        ///<value>Modificamos el atributo deleted del objeto. Los marcamos como true para que nos aparezca que esta eliminado</value> 
        public void RemoveCompanyMaterial()
        {
            this.Deleted=true;
        }

        /// <summary>
        /// Agregar habilitacion para el uso del materialEmpresa
        /// </summary>
        ///<value>Agregamos a la lista de habilitaciones, la habilitacion pasada por parametro. Esto pasa si y solo si la habilitacion no esta agregada previamente</value>
        /// <param name="pQualification">Se pasa la habilitacion a agregar</param>
        public void AddQualification(Qualification pQualification)
        {
            if(!this.Qualifications.Contains(pQualification))
            {
                this.Qualifications.Add(pQualification);
            }
        }

        /// <summary>
        /// Eliminar habilitacion para el uso del materialEmpresa
        /// </summary>
        ///<value>Eliminamos a la lista de habilitaciones, la habilitacion pasada por parametro. Esto pasa si y solo si la habilitacion esta agregada previamente</value>
        ///<param name="pQualification">Se pasa la habilitacion a eliminar</param>
        public void RemoveQualification(Qualification pQualification)
        {
            if(this.Qualifications.Contains(pQualification))
            {
                this.Qualifications.Remove(pQualification);
            }
        }

        /// <summary>
        /// Buscar la cantidad de stock del materialEmpresa que hay que una lugar
        /// </summary>
       /// <returns>
        /// Retornamos xretorno con la cantidad de stock que tiene el materialEmpresa en ese lugar.
        /// </returns>
        ///<param name="pLocation">Lugar en el cual buscamos cuanto stock hay</param>
        public int GetStockForLocation(Location pLocation)
        {
            int xretorno=0;
            int xIndex= this.GetIndexOfStockFromLocation(pLocation);
            xretorno=this.StockPerLocations[xIndex].Stock;
            return xretorno;
        }

        /// <summary>
        /// Obtiene la cantidad TOTAL de stock que hay de un materialEmpresa
        /// </summary>
       /// <returns>
        /// Retornamos xretorno con la suma de todos los stocks de todos los lugares donde esta almacenado el materialEmpresa.
        /// </returns>
        ///<param name="pLocation">Lugar en el cual buscamos cuanto stock hay</param>
        public int GetStockTotal()
        {
            int xretorno=0;
            foreach (CompanyStock xItem in this.StockPerLocations)
            {
                xretorno=xretorno+xItem.Stock;
            }
            return xretorno;
        }

        /// <summary>
        /// Hace un reabastecimiento del stock del materialEmpresa que hay en un lugar en particular
        /// </summary>
        ///<param name="pLocation">Lugar en el cual vamos a hacer el reabastecimiento</param>
        /// ///<param name="pStock">Cantidad de stock que vamos a reabastecer</param>
        public void RestockLocation(Location pLocation, int pStock)
        {
            int xIndex=this.GetIndexOfStockFromLocation(pLocation);
            this.StockPerLocations[xIndex].Stock=pStock;
        }

        /// <summary>
        /// Obtiene el indice en el cual esta el CompanyStock
        /// </summary>
       /// <returns>
        /// Retornamos xretorno el idice en el cual se encuentra el CompanyStock dentro de nuestra lista de StockPerLocation.
        /// </returns>
        ///<param name="pLocation">Lugar en el cual buscamos cuanto stock hay</param>
        public int GetIndexOfStockFromLocation(Location pLocation)
        {
            int xretorno=0;
            bool xEsta=false;
            while(xretorno<this.StockPerLocations.Count && xEsta==false)
            {
                if(this.StockPerLocations[xretorno].Location==pLocation)
                {
                    xEsta=true;
                }
                else
                {
                    xretorno++;
                }
            }
            return xretorno;
        }
    }
}
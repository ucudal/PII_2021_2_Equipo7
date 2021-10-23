using System;
using System.Collections.Generic;
using System.Collections;

namespace ClassLibrary
{
    /// <summary>
    /// clase administradora de company
    /// </summary>
    public class CompanyAdmin: DataAdmin<Company>
    {
        /// <summary>
        /// creo una nueva company 
        /// </summary>
        /// <returns>nuevo objeto company</returns>
        public override Company New()
        {
            Company xretorno=new Company();
            return xretorno;
        }
        /// <summary>
        /// claculo el indice final para poner la company
        /// </summary>
        /// <returns>indice final</returns>
        private int CalculadoraDeIndice()
        {
            int xretorno=Items.Count;
            return xretorno;
        }

        /// <summary>
        /// agrago una company a la lista
        /// </summary>
        /// <param name="company">paso por parametros un objeto de company</param>
        public override void Insert(Company company)
        {
            company.Id=CalculadoraDeIndice();
            if(!Items.Contains(company))
            {
                Items.Add(company);
            }
        }

        /// <summary>
        /// elimino una company
        /// </summary>
        /// <param name="company">paso por parametro el objeto company que quiero eliminar</param>
        public override void Delete(Company company)
        {
            if(Items.Contains(company))
            {
                Items[Items.IndexOf(company)].Deleted=true;
            }
        }
        /// <summary>
        /// modifico un objeto de company
        /// </summary>
        /// <param name="company">paso una company por parametro ya modificada</param>
        public override void Update(Company company)
        {
            Items[Items.IndexOf(this.GetById(company.Id))]=company;
        }      
        /// <summary>
        /// metodo para obtener una company por id
        /// </summary>
        /// <param name="companyid">id de la company</param>
        /// <returns>objeto de company</returns>
        public override Company GetById(int companyid)
        {
            Company companyfinal=null;
            int i=0;
            bool esesta =false;
            
            while(i<Items.Count && esesta==false)
            {
                if(Items[i].Id==companyid)
                {
                    esesta=true;
                    companyfinal=Items[i];
                }
            }
            return companyfinal;
        }
        /// <summary>
        /// obtener una compania por nombre
        /// </summary>
        /// <param name="nombre">paso el nombre por parametro</param>
        /// <returns>objeto de company</returns>
        public override Company GetByName(string nombre)
        {
            Company nombreFinal=null;
            int i=0;
            bool esesta=false;
            
            while(i<Items.Count && !esesta)
            {
                if(Items[i].Name == nombre)
                {
                    esesta=true;
                    nombreFinal=Items[i];
                }
            }
            return nombreFinal;
        }


    }
    

}


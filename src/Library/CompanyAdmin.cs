using System;
using System.Collections.Generic;
using System.Collections;

namespace Library
{
    public class CompanyAdmin: DataAdmin<Company>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Company New()
        {
            Company xretorno=new Company();
            return xretorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int CalculadoraDeIndice()
        {
            int xretorno=Items.Count;
            return xretorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        public override void Insert(Company company)
        {
            company.Id=CalculadoraDeIndice();
            if(!Items.Contains(company))
            {
                Items.Add(company);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        public override void Delete(Company company)
        {
            if(Items.Contains(company))
            {
                Items[Items.IndexOf(company)].Deleted=true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        public override void Update(Company company)
        {
            Items[Items.IndexOf(this.GetById(company.Id))]=company;
        }      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public override Company GetByName(string Nombre)
        {
            Company nombreFinal=null;
            int i=0;
            bool esesta=false;
            
            while(i<Items.Count && !esesta)
            {
                if(Items[i].Name==nombreFinal)
                {
                    esesta=true;
                    nombreFinal=Items[i];
                }
            }
            return nombreFinal;
        }


    }
    

}


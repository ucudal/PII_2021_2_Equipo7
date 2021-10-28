using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para la administración de las habilitaciones.
    /// </summary>
    public class QualificationAdmin : DataAdmin<Qualification>
    {
        public Qualification FindQualificationById(int pId)
        {
           Qualification xretorno=this.Items.Find(obj => obj.Id==pId);
            return xretorno;
        }
    }

}
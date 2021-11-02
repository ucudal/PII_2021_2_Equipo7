using System;
using System.Collections.Generic;
using System.Collections;

namespace ClassLibrary
    
{    
    /// <summary>
    /// clase location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// valor de georeferencia
        /// </summary>
        /// <value>string de georeferencia</value>
    public string Georeference{get;set;}
    /// <summary>
    /// constructor vacio de location
    /// </summary>
    public Location()
    {
        
    }
    /// <summary>
    /// constructor de location
    /// </summary>
    /// <param name="Georeference">georeferenciacion</param>
        public Location(string Georeference)
    {
        this.Georeference=Georeference;
    }

    }
    
}
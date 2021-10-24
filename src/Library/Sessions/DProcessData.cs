using System;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de los datos de un procedimiento
    /// multi-dialogo. Utilizado para almacenar datos
    /// temporales de un proceso en un punto del dialogo
    /// con el Bot para su uso en otros.
    /// </summary>
    public class DProcessData
    {
        private string code;
        private string initiator;
        private Type typeOfData;
        private dynamic data;

        /// <summary>
        /// Crea un contenedor nuevo.
        /// </summary>
        /// <param name="code">
        /// Codigo identificador del proceso.
        /// </param>
        /// <param name="initiator">
        /// Codigo del <p>DiscussionHandler</p>
        /// que inicia el proceso.
        /// </param>
        /// <param name="data">
        /// Objeto que contiene los datos especificos del proceso.
        /// </param>
        public DProcessData(string code, string initiator, dynamic data)
        {
            this.code = code;
            this.initiator = code;
            this.data = data;
            this.typeOfData = data?.GetType();
        }

        /// <summary>
        /// Devuelve el objeto con los datos especificos del proceso.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo del objeto que se busca devolver.
        /// </typeparam>
        public T GetData<T>() where T : class
        {
            if (typeof(T) == this.typeOfData)
            {
                return (T)this.data;
            }
            return null;
        }

        /// <summary>
        /// Tipo del objeto que contiene los datos del proceso.
        /// </summary>
        public Type TypeOfData { get => this.typeOfData; }
        
        /// <summary>
        /// Codigo identificador del proceso.
        /// </summary>
        public string Code { get => this.code; }
        
        /// <summary>
        /// Codigo del <p>DiscussionHandler</p>
        /// que inicia el proceso.
        /// </summary>
        public string Initiator { get => this.initiator; }
    }
}
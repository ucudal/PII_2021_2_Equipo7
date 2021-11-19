//-----------------------------------------------------------------------------------
// <copyright file="UserActivity.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de los datos de un procedimiento
    /// multi-dialogo. Utilizado para almacenar datos
    /// temporales de un proceso en un punto del dialogo
    /// con el Bot para su uso en otros.
    /// </summary>
    public class UserActivity
    {
        private readonly string code;
        private readonly string initiatorContext;
        private readonly string initiatorRoute;
        private readonly Type typeOfData;
        private ActivityData data;
        private bool terminate;
        private bool chainHandler;
        private string chainHandlerRoute;
        private string chainHandlerContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserActivity"/> class.
        /// Crea un contenedor nuevo.
        /// </summary>
        /// <param name="code">
        /// Codigo identificador del proceso.
        /// </param>
        /// <param name="initiatorContext">
        /// Contexto del handler inicializador.
        /// </param>
        /// <param name="initiatorRoute">
        /// Ruta del handler inicializador.
        /// </param>
        /// <param name="data">
        /// Objeto que contiene los datos especificos del proceso.
        /// </param>
        public UserActivity(string code, string initiatorContext, string initiatorRoute, ActivityData data)
        {
            this.code = code;
            this.initiatorContext = initiatorContext;
            this.initiatorRoute = initiatorRoute;
            this.data = data;
            this.typeOfData = data?.GetType();
            this.terminate = false;
            this.chainHandler = false;
            this.chainHandlerContext = null;
            this.chainHandlerRoute = null;
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
        /// Contexto del handler inicializador.
        /// </summary>
        public string InitiatorContext { get => this.initiatorContext; }

        /// <summary>
        /// Ruta del handler inicializador.
        /// </summary>
        public string InitiatorRoute { get => this.initiatorRoute; }

        /// <summary>
        /// Flag que indica si el proceso debe terminarse.
        /// </summary>
        public bool IsTerminating { get => this.terminate; }

        /// <summary>
        /// Flag de encadenamiento de handlers.
        /// </summary>
        public bool ChainHandler { get => this.chainHandler; }

        /// <summary>
        /// Ruta del handler encadenado.
        /// </summary>
        public string ChainHandlerRoute { get => this.chainHandlerRoute; }

        /// <summary>
        /// Contexto al que responde el handler encadenado.
        /// </summary>
        public string ChainHandlerContext { get => this.chainHandlerContext; }

        /// <summary>
        /// Devuelve el objeto con los datos especificos del proceso.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo del objeto que se busca devolver.
        /// </typeparam>
        /// <returns>
        /// Contenedor de datos.
        /// </returns>
        public T GetData<T>()
            where T : ActivityData
        {
            if (typeof(T) == this.typeOfData)
            {
                return (T)this.data;
            }

            return null;
        }

        /// <summary>
        /// Configura el flag de terminar actividad.
        /// </summary>
        /// <param name="chainInitiator">
        /// Mostrar mensaje siguiente enseguida o no.
        /// </param>
        public void Terminate(bool chainInitiator = true)
        {
            this.terminate = true;

            if (chainInitiator)
            {
                this.SetHandlerChain(this.initiatorContext, this.initiatorRoute);
            }
        }

        /// <summary>
        /// Configura un manejador de mensaje
        /// encadenado con el actual.
        /// </summary>
        /// <param name="context">
        /// Contexto al que responde el
        /// handler a encadenar.
        /// </param>
        /// <param name="route">
        /// Ruta a la que responde el
        /// handler a encadenar.
        /// </param>
        public void SetHandlerChain(string context, string route)
        {
            this.chainHandler = true;
            this.chainHandlerRoute = route;
            this.chainHandlerContext = context;
        }

        /// <summary>
        /// Remover handler encadenado.
        /// </summary>
        public void ClearHandlerChain()
        {
            this.chainHandler = false;
            this.chainHandlerRoute = null;
            this.chainHandlerContext = null;
        }
    }
}
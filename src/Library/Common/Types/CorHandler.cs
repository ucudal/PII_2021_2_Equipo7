using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase abstracta que forma la base para
    /// utilizar el patron Cadena de Responsabilidad.
    /// Especifica las operaciones y propiedades
    /// necesarias para implementar el patron.
    /// </summary>
    /// <typeparam name="T">
    /// Clase base de cualquier
    /// implementacion concreta del patron. Debe ser
    /// la misma clase abstracta que implementa 
    /// <c>CorHandler</c>.
    /// </typeparam>
    /// <typeparam name="K">
    /// Clase que define el selector que se utilizara
    /// para procesar que paso en la cadena sera el 
    /// que se ejecute.
    /// </typeparam>
    public abstract class CorHandler<T, K>
    {
        /// <summary>
        /// Siguiente objeto a procesar si este
        /// paso no es el indicado por el selector.
        /// </summary>
        protected T next;
        /// <summary>
        /// Codigo identificador el paso en la cadena.
        /// </summary>
        protected string code;

        /// <summary>
        /// Constructor base utilizado por las implementaciones
        /// de esta clase para asignar el <c>next</c> y <c>code</c>
        /// al crear instancias.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="code"></param>
        public CorHandler(T next, string code)
        {
            if (code is null) throw new ArgumentNullException("Se intento crear un handler sin codigo.");
            this.next = next;
            this.code = code;
        }

        /// <summary>
        /// Metodo a llamar desde el paso anterior para
        /// procesar este paso. Toda implementacion
        /// deberia evaluar el selector por una condicion
        /// y en base a esta llamar al <c>Execute()</c> de
        /// la misma instancia, o al <c>Next()</c> del
        /// siguiente paso.
        /// </summary>
        /// <param name="selector">
        /// Objeto con los datos para determinar que paso
        /// en la cadena se debe procesar, y tambien los
        /// necesarios para procesar el paso en si.
        /// </param>
        /// <returns>
        /// <c>string</c> con el resultado
        /// de procesar la cadena.
        /// </returns>
        public abstract string Next(K selector);

        /// <summary>
        /// Procesa el paso actual en base a los datos
        /// contenidos por <c>selector</c>.
        /// </summary>
        /// <param name="selector">
        /// Objeto con los datos necesarios para procesar
        /// el paso actual.
        /// </param>
        /// <returns>
        /// <c>string</c> con el resultado
        /// de procesar el paso.
        /// </returns>
        public abstract string Execute(K selector);
    }
}
// -----------------------------------------------------------------------
// <copyright file="CorHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

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
    /// <typeparam name="TK">
    /// Clase que define el selector que se utilizara
    /// para procesar que paso en la cadena sera el
    /// que se ejecute.
    /// </typeparam>
    public abstract class CorHandler<T, TK>
    {
        /// <summary>
        /// Siguiente objeto a procesar si este
        /// paso no es el indicado por el selector.
        /// </summary>
        private T next;

        /// <summary>
        /// Codigo identificador el paso en la cadena.
        /// </summary>
        private string code;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorHandler{T, TK}"/> class.
        /// Constructor base utilizado por las implementaciones
        /// de esta clase para asignar el <c>next</c> y <c>code</c>
        /// al crear instancias.
        /// </summary>
        /// <param name="next">
        /// Siguiente objeto a procesar si este
        /// paso no es el indicado por el selector.
        /// </param>
        /// <param name="code">
        /// Codigo identificador el paso en la cadena.
        /// </param>
        protected CorHandler(T next, string code)
        {
            if (code is null)
            {
                throw new ArgumentNullException(paramName: nameof(code));
            }

            this.next = next;
            this.code = code;
        }

        /// <summary>
        /// Siguiente objeto a procesar si este
        /// paso no es el indicado por el selector.
        /// </summary>
        public T Next
        {
            get => this.next;
            set => this.next = value;
        }

        /// <summary>
        /// Codigo identificador el paso en la cadena.
        /// </summary>
        public string Code
        {
            get => this.code;
            set => this.code = value;
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
        public abstract string NextLink(TK selector);

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
        public abstract string Execute(TK selector);
    }
}
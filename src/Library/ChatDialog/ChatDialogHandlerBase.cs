// -----------------------------------------------------------------------
// <copyright file="ChatDialogHandlerBase.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ClassLibrary
{
    /// <summary>
    /// Clase base para la implementacion del patron
    /// Cadena de Responsabilidad a los dialogos de
    /// chat con el Bot, Todos los pasos de la cadena
    /// representando dialogos con el Bot deben implementar
    /// esta clase.
    /// </summary>
    public abstract class ChatDialogHandlerBase : CorHandler<ChatDialogHandlerBase, ChatDialogSelector>
    {
        /// <summary>
        /// Comando al que responde el paso concreto
        /// en caso de ser nulo, se debe sobreescribir
        /// el <see cref="ValidateDataEntry(ChatDialogSelector)"/> con la nueva
        /// condicion a evaluar.
        /// </summary>
        private string route;

        /// <summary>
        /// Listado de pasos concretos por su codigo
        /// donde el usuario debe estar ubicado
        /// (su contexto) para que este paso responda
        /// a un mensaje.
        /// </summary>
        private ICollection<string> parents = new Collection<string>();

        /// <summary>
        /// Objeto contenedor de las sesiones
        /// de de usuarios.
        /// </summary>
        private SessionsContainer sessions = Singleton<SessionsContainer>.Instance;

        /// <summary>
        /// Acceso a los administradores de datos
        /// persistentes.
        /// </summary>
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatDialogHandlerBase"/> class.
        /// Constructor que actua de intermediario entre la el paso
        /// concreto y <see cref="CorHandler{T,K}"/> para configurar el siguiente paso
        /// y el codigo identificador de paso en la cadena.
        /// </summary>
        /// <param name="next">
        /// Siguiente handler en la cadena de
        /// responsabilidad.
        /// </param>
        /// <param name="code">
        /// Codigo identificador del handler concreto en la cadena.
        /// </param>
        protected ChatDialogHandlerBase(ChatDialogHandlerBase next, string code)
            : base(next, code)
        {
        }

        /// <summary>
        /// Comando al que responde el paso concreto
        /// en caso de ser nulo, se debe sobreescribir
        /// el <see cref="ValidateDataEntry(ChatDialogSelector)"/> con la nueva
        /// condicion a evaluar.
        /// </summary>
        public string Route
        {
            get => this.route;
            set => this.route = value;
        }

        /// <summary>
        /// Listado de pasos concretos por su codigo
        /// donde el usuario debe estar ubicado
        /// (su contexto) para que este paso responda
        /// a un mensaje.
        /// </summary>
        public ICollection<string> Parents
        {
            get => this.parents;
        }

        /// <summary>
        /// Objeto contenedor de las sesiones
        /// de de usuarios.
        /// </summary>
        public SessionsContainer Sessions
        {
            get => this.sessions;
            set => this.sessions = value;
        }

        /// <summary>
        /// Acceso a los administradores de datos
        /// persistentes.
        /// </summary>
        public DataManager DatMgr
        {
            get => this.datMgr;
            set => this.datMgr = value;
        }

        /// <summary>
        /// Llama a <see cref="ValidateDataEntry(ChatDialogSelector)"/> para evaluar si
        /// este handler es el correcto que debe ejecutar su codigo.
        /// Si no lo es, llama al handler siguiente en la cadena.
        /// </summary>
        /// <param name="selector">
        /// Contenedor con los datos para evaluar si este es el paso
        /// correcto, y con aquellos necesarios para ejecutar el
        /// codigo asociado al paso.
        /// </param>
        /// <returns>
        /// <c>string</c> con el mensaje de respuesta
        /// al usuario.
        /// </returns>
        public override string NextLink(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.ValidateDataEntry(selector))
            {
                Session session = this.sessions.GetSession(selector.Service, selector.Account);
                session.MenuLocation = this.Code;
                return this.Execute(selector);
            }
            else
            {
                if (this.Next is null)
                {
                    string msg = "Se intento pasar al proximo paso, pero el objeto relevante 'next' esta vacio.";
                    Debug.WriteLine($"Excepcion: {msg}");
                    /*throw new NullReferenceException(msg);*/
                }

                return this.Next.NextLink(selector);
            }
        }

        /// <summary>
        /// Valida de acuerdo al selector, si el handler actual es
        /// el correcto que debe ejecutar su codigo.
        /// </summary>
        /// <param name="selector">
        /// Contenedor con los datos para evaluar si este es el paso
        /// correcto.
        /// </param>
        /// <returns>
        /// <c>bool</c> indicando si el handler actual
        /// es el correcto o no.
        /// </returns>
        public virtual bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context) || (selector.Context is null && this.Parents.Count == 0))
            {
                if (this.Route == selector.Code)
                {
                    Session session = this.sessions.GetSession(selector.Service, selector.Account);
                    session.MenuLocation = this.Code;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
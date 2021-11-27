// -----------------------------------------------------------------------
// <copyright file="CDHQualificationsAddBadUrl.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Confirmación de añadir habilitación.
    /// </summary>
    public class CDHQualificationsAddBadUrl : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHQualificationsAddBadUrl"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHQualificationsAddBadUrl(ChatDialogHandlerBase next)
        : base(next, "Qualifications_Add_Bad_Url")
        {
            this.Parents.Add("Qualifications_Add_DocUrl");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string NextLink(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.ValidateDataEntry(selector))
            {
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

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            return "Formato de URL invalido, intente de nuevo.";
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            if (this.Parents.Contains(selector.Context))
            {
                if (!selector.Code.StartsWith('/'))
                {
                    return !Uri.TryCreate(selector.Code, UriKind.Absolute, out _);
                }
            }

            return false;
        }
    }
}
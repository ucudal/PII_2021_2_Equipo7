// -----------------------------------------------------------------------
// <copyright file="CDH_SignUpEntrepreneurTrade.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde a la introduccion del nombre de la
    /// empresa a agregar. Procede a pedirle al
    /// usuario introducir el oficio de la Empresa.
    /// </summary>
    public class CDH_SignUpEntrepreneurTrade : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_SignUpEntrepreneurTrade"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_SignUpEntrepreneurTrade"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_SignUpEntrepreneurTrade(ChatDialogHandlerBase next)
            : base(next, "registration_new_entre_trade")
        {
            this.Parents.Add("registration_new_entre_name");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Entrepreneur entrepreneur = this.DatMgr.Entrepreneur.New();
            entrepreneur.Name = selector.Code;

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            SignUpData data = session.Process.GetData<SignUpData>();
            data.Entrepreneur = entrepreneur;

            StringBuilder builder = new StringBuilder();
            builder.Append("Ingrese el oficio de su <b>emprendimiento</b>.");
            return builder.ToString();
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
                if (!selector.Code.StartsWith('\\'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
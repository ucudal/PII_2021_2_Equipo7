// -----------------------------------------------------------------------
// <copyright file="CDH_WelcomeEntrepreneur.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// emprendedor.
    /// </summary>
    public class CDH_WelcomeEntrepreneur : ChatDialogHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDH_WelcomeEntrepreneur"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="CDH_WelcomeEntrepreneur"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_WelcomeEntrepreneur(ChatDialogHandlerBase next)
            : base(next, "welcome_entrepreneur")
        {
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Usted es un emprendedor.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\buscarpublicacion : Buscar publicaciones.\n");
            builder.Append("\\regeneracionmaterial : Muestra la regeneración del material.\n");
            builder.Append("\\historialcompras: Mostrar historial de compra.");
            builder.Append("\\habilitaciones: Menú de habilitaciones.");
            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool ValidateDataEntry(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            User user = this.DatMgr.User.GetById(session.UserId);
            if (selector.Code == "/welcome" && user.Role == UserRole.Entrepreneur)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
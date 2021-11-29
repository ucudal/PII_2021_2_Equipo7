// -----------------------------------------------------------------------
// <copyright file="CDHCompanyAddLocationMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyAddLocationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyAddLocationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyAddLocationMenu(ChatDialogHandlerBase next)
            : base(next, "company_location_add_menu")
        {
            this.Parents.Add("company_location_menu");
            this.Route = "/ingresar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            InsertCompanyLocationData data = new InsertCompanyLocationData()
            {
                CompLoc = this.DatMgr.CompanyLocation.New(),
            };
            data.CompLoc.CompanyId = session.EntityId;
            UserActivity activity = new UserActivity("comp_add_loc", "welcome_company", "/localizaciones", data);
            session.PushActivity(activity);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingrese la <b>direccion</b> de la localizacion:.\n");
            builder.Append("/volver - Volver al menu de localizaciones.");
            return builder.ToString();
        }
    }
}
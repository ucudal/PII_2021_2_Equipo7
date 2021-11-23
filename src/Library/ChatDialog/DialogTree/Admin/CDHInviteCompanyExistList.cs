// -----------------------------------------------------------------------
// <copyright file="CDHInviteCompanyExistList.cs" company="Universidad Católica del Uruguay">
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
    /// administrador de empresa.
    /// </summary>
    public class CDHInviteCompanyExistList : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHInviteCompanyExistList"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHInviteCompanyExistList(ChatDialogHandlerBase next)
        : base(next, "invite_company_exist_list")
        {
            this.Parents.Add("invitemenu");
            this.Route = "/compania_existente";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            builder.Append("Listado de Companias existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre alguna compania ingrese su numero.\n");
            builder.Append("\\cancelar : Volver a menu.\n");
            builder.Append(this.TextToPrintQualification());
            builder.Append("LISTADO_CATMAT");
            return builder.ToString();
        }

        private string TextToPrintQualification()
        {
            StringBuilder xListMats = new StringBuilder();

            foreach (Company company in this.DatMgr.Company.Items)
            {
                xListMats.Append(" " + company.Name + " " + company.Id + "\n");
            }

            return xListMats.ToString();
        }
    }
}
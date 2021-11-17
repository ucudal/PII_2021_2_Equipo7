// -----------------------------------------------------------------------
// <copyright file="CDH_Search_Location_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Busca una publicación con una locación.
    /// </summary>
    public class CDH_Search_Location_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Search_Location_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Search_Location_Menu(ChatDialogHandlerBase next)
        : base(next, "Search_Location_Menu")
        {
            this.Parents.Add("Search_Publication_Menu");
            this.Route = "\\localidad";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            builder.Append("Menu para ingresar localidad \n");
            builder.Append(this.TextToPrintLocationCompany());
            builder.Append("Ingrese el id de la localidad.\n");
            builder.Append("\\cancelar : Volver a menu de busqueda .\n");
            return builder.ToString();
        }

        private string TextToPrintLocationCompany()
        {
            StringBuilder listlocation = new StringBuilder();
            foreach (CompanyLocation location in this.DatMgr.CompanyLocation.Items)
            {
               listlocation.Append($" Identificador de la location - {location.Id}\n");
            }

            return listlocation.ToString();
        }
    }
}
// -----------------------------------------------------------------------
// <copyright file="CDH_List_Location_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones por localidad.
    /// </summary>
    public class CDH_List_Location_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_List_Location_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_List_Location_Menu(ChatDialogHandlerBase next)
        : base(next, "List_Location_Menu")
        {
            this.Parents.Add("Search_Location_Menu");
            this.Route = null;
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
            SearchPublication data = new SearchPublication();
            data.Location = this.DatMgr.CompanyLocation.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            DProcessData process = new DProcessData("search_Publication_By_Location", this.Code, data);
            builder.Append($"Listado de publicaciones con el id de localidad ingresada - {selector.Code} \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            builder.Append("LISTADO DE PUBLICACIONES:");
            builder.Append(this.TextToPrintPublicationMaterialLocation(selector, data));
            builder.Append("Ingrese el id de la publicación para ver los detalles de la publicacion.\n");
            return builder.ToString();
        }

        private string TextToPrintPublicationMaterialLocation(ChatDialogSelector selector, SearchPublication data)
        {
            StringBuilder listpublicaciones = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            foreach (Publication publi in this.DatMgr.Publication.Items)
            {
                if (publi.Location.Id == data.Location.Id && publi.Deleted == false)
                {
                    Publication publication = this.DatMgr.Publication.GetById(publi.Id);
                    CompanyMaterial mat = this.DatMgr.CompanyMaterial.GetById(publication.CompanyMaterialId);
                    listpublicaciones.Append($" Identificador de la publicación - {publication.Id}, nombre del material - {mat.Name}\n");
                }
            }

            return listpublicaciones.ToString();
        }
    }
}
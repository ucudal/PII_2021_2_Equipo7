// -----------------------------------------------------------------------
// <copyright file="CDH_List_Category_Menu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Muestra una lista de publicaciones por localidad.
    /// </summary>
    public class CDH_List_Category_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_List_Category_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_List_Category_Menu(ChatDialogHandlerBase next)
        : base(next, "List_Category_Menu")
        {
            this.Parents.Add("Search_Category_Menu");
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
            DProcessData process = new DProcessData("search_Publication_By_Category", this.Code, data);

            builder.Append($"Listado de publicaciones con el id de categoria ingresada - {selector.Code} \n");
            builder.Append("Ademas puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\siguiente : Siguiente pagina de publicaciones.\n");
            builder.Append("\\anterior: Pagina anterior de publicaciones.\n");
            builder.Append("\\cancelar : Volver a menu de buscar publicacion por localidad.\n");
            builder.Append(this.TextToPrintPublicationMaterialCategory(selector));
            builder.Append("LISTADO DE PUBLICACIONES");
            builder.Append("Ingrese el id de la publicación para comprar.\n");
            return builder.ToString();
        }

        private string TextToPrintPublicationMaterialCategory(ChatDialogSelector selector)
        {
            StringBuilder listpublicaciones = new StringBuilder();

            IReadOnlyCollection<int> xListaMaterialesEnCat = this.DatMgr.CompanyMaterial.GetCompanyMaterialsForCategory(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            foreach (int i in xListaMaterialesEnCat)
            {
               IReadOnlyCollection<int> xPublicationsPerMat = this.DatMgr.Publication.GetPublicationsWithCompanyMaterial(i);
               foreach (int j in xPublicationsPerMat)
               {
                   Publication xPubli = this.DatMgr.Publication.GetById(j);
                   listpublicaciones.Append(" Identificador de la publicacion - " + xPubli.Id + "nombre del material - " + this.DatMgr.CompanyMaterial.GetById(i).Name + " \n");
               }
            }

            return listpublicaciones.ToString();
        }
    }
}
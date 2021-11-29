// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationQuantityMaterialToAddMenu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationQuantityMaterialToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationQuantityMaterialToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationQuantityMaterialToAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_quantity_material_to_add_menu")
        {
            this.Parents.Add("company_publication_list_material_to_add_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertPublicationData data = process.GetData<InsertPublicationData>();

            Publication pub = this.DatMgr.Publication.New();
            pub.CompanyMaterialId = int.Parse(selector.Code, CultureInfo.InvariantCulture);
            pub.CompanyId = session.EntityId;
            data.Publication = pub;
            session.CurrentActivity = process;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Ingrese la <b>cantidad</b> del material que quiere agregar a la publicacion:\n");
            builder.Append("/volver - Listar todos los materiales que ya posee.\n");
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
                if (!selector.Code.StartsWith('/'))
                {
                    CompanyMaterial xMat = this.DatMgr.CompanyMaterial.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (xMat is not null)
                    {
                        Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                        if (xMat.CompanyId == session.EntityId && session.UserRole == UserRole.CompanyAdministrator)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
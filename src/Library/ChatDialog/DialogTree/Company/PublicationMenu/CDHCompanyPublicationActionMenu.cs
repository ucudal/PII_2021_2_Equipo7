// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationActionMenu.cs" company="Universidad Católica del Uruguay">
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
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationActionMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationActionMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationActionMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_action_menu")
        {
            this.Parents.Add("company_publication_list_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            ErasePublicationData data = new ErasePublicationData();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            UserActivity process = new UserActivity("select_publication", "company_publication_menu", "/listar", data);
            data.Publication = this.DatMgr.Publication.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            session.PushActivity(process);

            process = session.CurrentActivity;
            data = process.GetData<ErasePublicationData>();
            Publication pub = this.DatMgr.Publication.GetById(data.Publication.Id);
            CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(pub.CompanyMaterialId);
            Company comp = this.DatMgr.Company.GetById(pub.CompanyId);
            int stock = this.DatMgr.CompanyMaterialStock.GetStockTotalForCompanyMaterial(compMat.Id);
            IReadOnlyCollection<int> qualifications = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(pub.CompanyMaterialId);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"<b>Detalles: {pub.Title}</b>\n");
            builder.AppendLine($"<b>Material</b>: {compMat.Name}");
            builder.AppendLine($"<b>Stock</b>: {stock}");
            builder.AppendLine($"<b>Vendedor</b>: {comp.Name}\n");
            builder.AppendLine($"<b>Descripcion</b>:\n{pub.Description}\n");
            builder.AppendLine("<b>Habilitaciones</b>:");
            bool hasAllQualifications = true;
            bool hasQualification;
            string line;
            foreach (int qualificationId in qualifications)
            {
                Qualification qualification = this.DatMgr.Qualification.GetById(qualificationId);
                hasQualification = this.DatMgr.EntrepreneurQualification.GetEntrepreneurHasQualification(session.EntityId, qualificationId);
                line = hasQualification ? $"{qualification.Name}" : $"{qualification.Name} (Falta)";
                builder.AppendLine(line);
                hasAllQualifications &= hasQualification;
            }

            if (qualifications.Count == 0)
            {
                builder.AppendLine("Sin habilitaciones requeridas.");
            }

            builder.AppendLine($"\n<b>Cantidad</b>: {pub.Quantity}");
            builder.AppendLine($"<b>Moneda</b>: {Enum.GetName(typeof(Currency), pub.Currency)}");
            builder.AppendLine($"<b>Precio</b>: {pub.Price}\n");
            builder.AppendLine("/eliminar - Eliminar la publicacion.\n");
            builder.Append("/volver - Volver a la lista de publicaciones.\n");
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
                    Publication publication = this.DatMgr.Publication.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (publication is not null)
                    {
                        Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                        if (publication.CompanyId == session.EntityId && session.UserRole == UserRole.CompanyAdministrator)
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
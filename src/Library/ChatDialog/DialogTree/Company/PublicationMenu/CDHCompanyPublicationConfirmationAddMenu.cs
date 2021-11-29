// -----------------------------------------------------------------------
// <copyright file="CDHCompanyPublicationConfirmationAddMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyPublicationConfirmationAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyPublicationConfirmationAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyPublicationConfirmationAddMenu(ChatDialogHandlerBase next)
            : base(next, "company_publication_confirmation_add_menu")
        {
            this.Parents.Add("company_publication_loc_material_to_add_menu");
            this.Route = null;
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            int id = int.Parse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture);
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            UserActivity process = session.CurrentActivity;
            InsertPublicationData data = process.GetData<InsertPublicationData>();
            data.Publication.CompanyLocationId = id;
            session.CurrentActivity = process;

            Publication pub = data.Publication;
            CompanyMaterial compMat = this.DatMgr.CompanyMaterial.GetById(pub.CompanyMaterialId);
            Company comp = this.DatMgr.Company.GetById(pub.CompanyId);
            int stock = this.DatMgr.CompanyMaterialStock.GetStockTotalForCompanyMaterial(compMat.Id);
            IReadOnlyCollection<int> qualifications = this.DatMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(pub.CompanyMaterialId);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Seguro que desea crear un material con los siguientes datos.\n");
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
            builder.AppendLine("/confirmar - Confirmar la operacion.");
            builder.AppendLine("/volver - Volver al menu de publicaciones.");
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
                    if (int.TryParse(selector.Code, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
                    {
                        CompanyLocation compLoc = this.DatMgr.CompanyLocation.GetById(id);
                        if (compLoc is not null)
                        {
                            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                            if (compLoc.CompanyId == session.EntityId && session.UserRole == UserRole.CompanyAdministrator)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
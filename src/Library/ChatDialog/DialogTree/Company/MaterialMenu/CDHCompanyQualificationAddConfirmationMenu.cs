// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationAddConfirmationMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyQualificationAddConfirmationMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationAddConfirmationMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationAddConfirmationMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualification_add_confirmation_menu")
        {
            this.Parents.Add("company_qualification_list_to_add_menu");
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
            UserActivity activity = session.CurrentActivity;
            SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            Qualification habilitaciones = this.DatMgr.Qualification.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
            data.Qualification = habilitaciones;

            StringBuilder builder = new StringBuilder();
            builder.Append("Seguro que desea añadir esta habilitacion al material.\n");
            builder.Append("Nombre: " + data.Qualification.Name);
            builder.Append("Nombre: NOMBRE\n");
            builder.Append("/confirmar : En caso de querer confirmar la operacion.\n");
            builder.Append("/volver : Volver al menu principal de materiales.\n");
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
                    Qualification qualification = this.DatMgr.Qualification.GetById(int.Parse(selector.Code, CultureInfo.InvariantCulture));
                    if (qualification is not null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
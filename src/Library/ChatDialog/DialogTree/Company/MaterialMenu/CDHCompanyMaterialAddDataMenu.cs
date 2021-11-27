// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialAddDataMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialAddDataMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialAddDataMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialAddDataMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_add_data_menu")
        {
            this.Parents.Add("company_material_add_confirmation_menu");
            this.Route = "/confirmar";
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
            InsertCompanyMaterialData data = activity.GetData<InsertCompanyMaterialData>();
            data.RunTask();
            StringBuilder builder = new StringBuilder();
            builder.Append("El material se agrego satisfactoriamente.\n");
            builder.Append("Escriba ");
            builder.Append("/volver : para volver al menu de materiales.\n");
            return builder.ToString();
        }
    }
}
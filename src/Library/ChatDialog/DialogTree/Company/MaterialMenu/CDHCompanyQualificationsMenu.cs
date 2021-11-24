// -----------------------------------------------------------------------
// <copyright file="CDHCompanyQualificationsMenu.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDHCompanyQualificationsMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyQualificationsMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyQualificationsMenu(ChatDialogHandlerBase next)
            : base(next, "company_qualifications_menu")
        {
            this.Parents.Add("company_actions_material_menu");
            this.Route = "/habilitaciones";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector != null)
            {
                Session session = this.Sessions.GetSession(selector.Service, selector.Account);
                UserActivity activity = session.CurrentActivity;
                SelectCompanyMaterialData data = activity.GetData<SelectCompanyMaterialData>();
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Menu de habilitaciones.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("/eliminar : Listar todas las habilitaciones del material que se pueden eliminar.\n");
            builder.Append("/agregar : Agregar una habilitacion al material.\n");
            builder.Append("/volver : Volver al menu de materiales .\n");
            return builder.ToString();
        }
    }
}
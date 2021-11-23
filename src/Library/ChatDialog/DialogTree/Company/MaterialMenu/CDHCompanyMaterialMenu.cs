// -----------------------------------------------------------------------
// <copyright file="CDHCompanyMaterialMenu.cs" company="Universidad Católica del Uruguay">
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
    public class CDHCompanyMaterialMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHCompanyMaterialMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHCompanyMaterialMenu(ChatDialogHandlerBase next)
        : base(next, "company_material_menu")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/materiales";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu de materiales.\n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append("\\ingresar : Ingresar un material nuevo.\n");
            builder.Append("\\listar : Listar todos los materiales que ya posee.\n");
            return builder.ToString();
        }
    }
}
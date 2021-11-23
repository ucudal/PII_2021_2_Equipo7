// -----------------------------------------------------------------------
// <copyright file="CDHRemoveQualificationRemove.cs" company="Universidad Católica del Uruguay">
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
    public class CDHRemoveQualificationRemove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHRemoveQualificationRemove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHRemoveQualificationRemove(ChatDialogHandlerBase next)
        : base(next, "hab_remove")
        {
            this.Parents.Add("hab_list");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(paramName: nameof(selector));
            }

            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);

            builder.Append("Listado de habilitaciones existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre alguna habilitaciom ingrese su numero.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(this.TextToPrintQualification());
            builder.Append("LISTADO_habilitaciones");
            return builder.ToString();
        }

        private string TextToPrintQualification()
        {
            StringBuilder xListMats = new StringBuilder();

            foreach (Qualification qualification in this.DatMgr.Qualification.Items)
            {
                xListMats.Append(" " + qualification.Name + " " + qualification.Id + "\n");
            }

            return xListMats.ToString();
        }
    }
}
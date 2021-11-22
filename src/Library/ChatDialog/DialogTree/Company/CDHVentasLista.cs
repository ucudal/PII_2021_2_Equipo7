// -----------------------------------------------------------------------
// <copyright file="CDH_VentasLista.cs" company="Universidad Católica del Uruguay">
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
    public class CDHVentasLista : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDHVentasLista"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDHVentasLista(ChatDialogHandlerBase next)
            : base(next, "listar_vetas")
        {
            this.Parents.Add("welcome_company");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Listado de Ventas existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre algun material ingrese su numero.\n");
            builder.Append("\\cancelar : Volver a menu de Empresa .\n");

            // builder.Append(TextToPrintCompanyMaterial(selector));
            return builder.ToString();
        }

        /*
        private string TextToPrintCompanyMaterial(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            Company company = this.companyAdmin.FindAdminUser(session.UserId);

            List<Sale> sales = this.saleAdmin.GetByCompanyId(company.Id);

            foreach(Sale sale  in sales)
            {
                xListMats.Append("en la fecha" + sale.DateTime.ToString() +"se compro" + sale.PublicationItem.CompanyMaterial.Name + "\n");
            }
            return xListMats.ToString();
        }*/
    }
}
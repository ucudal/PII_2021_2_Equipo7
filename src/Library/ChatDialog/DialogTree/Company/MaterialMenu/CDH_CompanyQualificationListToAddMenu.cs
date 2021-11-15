using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_CompanyQualificationListToAddMenu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_CompanyQualificationListToAddMenu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_CompanyQualificationListToAddMenu(ChatDialogHandlerBase next) : base(next, "company_qualification_list_to_add_menu")
        {
            this.parents.Add("company_qualifications_menu");
            this.route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu lista de habilitaciones.\n");
            builder.Append("Aparecen la lista de habilitaciones que puede agregar.\n");
            builder.Append("Ingrese el numero de la habilitacion que quiere agregar.\n");
            builder.Append("Sino, en caso de querer retornar escriba\n");
            builder.Append("/volver para volver al menu de materiales.\n");
            builder.Append(TextoToPrintQualifications(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }
        
        private string TextoToPrintQualifications(ChatDialogSelector selector)
        {
            StringBuilder builder=new StringBuilder();
            Session session = this.sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            List<Qualification> xhabilitacionesNoAgegadas=new List<Qualification>();
            int i=0;
            bool xSigo=true;
            foreach(Qualification xHabi in this.datMgr.Qualification.Items)
            {
                xSigo=true;
                IReadOnlyCollection<int> xHabilitaciones=this.datMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(data.CompanyMaterial.Id);
                while(i<xHabilitaciones.Count && xSigo==true)
                {
                   if(xHabi.Id==xHabilitaciones.ElementAt(i))
                   {
                       xSigo=false;
                       xhabilitacionesNoAgegadas.Add(xHabi);
                   } 
                }
            }
            foreach(Qualification x in xhabilitacionesNoAgegadas)
            {
                builder.Append(""+ x.Name+" "+ x.Id + "\n");
            }
            return builder.ToString();
        }
    }
}
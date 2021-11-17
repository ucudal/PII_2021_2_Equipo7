// -----------------------------------------------------------------------
// <copyright file="CDH_Confirmation_Sale_KeyWord.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Menú para añadir habilitación.
    /// </summary>
    public class CDH_Qualifications_Add_Menu : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Qualifications_Add_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Qualifications_Add_Menu(ChatDialogHandlerBase next) : base(next, "Qualifications_Add_Menu")
        {
            this.Parents.Add("Qualification_Menu");
            this.Route = "/agregar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu lista de habilitaciones.\n");
            builder.Append("lista de habilitaciones que puede agregar.\n");
            builder.Append("Ingrese el numero de la habilitacion que quiere agregar.\n");
            builder.Append("Sino, en caso de querer retornar escriba\n");
            builder.Append("\\volver para volver al menu de materiales.\n");
            builder.Append(TextoToPrintQualifications(selector));
            builder.Append("LISTADO_HABILITACIONES");
            return builder.ToString();
        }
        
        private string TextoToPrintQualifications(ChatDialogSelector selector)
        {
            StringBuilder builder=new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            DProcessData process = session.Process;
            SelectCompanyMaterialData data = process.GetData<SelectCompanyMaterialData>();
            List<Qualification> habilitacionesNoAgegadas=new List<Qualification>();
            int i=0;
            bool Sigo=true;
            foreach(Qualification Habi in this.DatMgr.Qualification.Items)
            {
                Sigo=true;
                IReadOnlyCollection<int> Habilitaciones=this.DatMgr.EntrepreneurQualification.GetQualificationsForEntrepreneur(session.UserId);
                while(i<Habilitaciones.Count && Sigo==true)
                {
                   if(Habi.Id==Habilitaciones.ElementAt(i))
                   {
                       Sigo=false;
                       habilitacionesNoAgegadas.Add(Habi);
                   } 
                }
            }
            foreach(Qualification x in habilitacionesNoAgegadas)
            {
                builder.Append(""+ x.Name+" "+ x.Id + "\n");
            }
            return builder.ToString();
        }
    }
}
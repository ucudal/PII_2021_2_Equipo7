using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un usuario
    /// administrador de empresa.
    /// </summary>
    public class CDH_RemoveQualificationRemove : ChatDialogHandlerBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_RemoveQualificationRemove"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_RemoveQualificationRemove(ChatDialogHandlerBase next) : base(next, "hab_remove")
        {
            this.Parents.Add("hab_list");
            this.Route = "/listar";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            Session session = this.Sessions.GetSession(selector.Service, selector.Account);
            
            builder.Append("Listado de habilitaciones existentes: \n");
            builder.Append("En caso de querer hacer una accion sobre alguna habilitaciom ingrese su numero.\n");
            builder.Append("\\cancelar : Volver a menu de materiales .\n");
            builder.Append(TextToPrintQualification(selector));
            builder.Append("LISTADO_habilitaciones");
            return builder.ToString();
        }
        
        private string TextToPrintQualification(ChatDialogSelector selector)
        {
            StringBuilder xListMats=new StringBuilder();
            
            
            foreach( Qualification qualification in this.DatMgr.Qualification.Items)
            {
                
                xListMats.Append("" + qualification.Name +" " +qualification.Id + "\n");
            }
            return xListMats.ToString();
        }
    }
}
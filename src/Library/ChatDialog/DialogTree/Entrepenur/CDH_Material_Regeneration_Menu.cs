using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// <see cref="ChatDialogHandlerBase"/> concreto:
    /// Responde al inicio de un emprendedor.
    /// </summary>
    public class CDH_Material_Regeneration_Menu : ChatDialogHandlerBase
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CDH_Material_Regeneration_Menu"/>.
        /// </summary>
        /// <param name="next">Siguiente handler.</param>
        public CDH_Material_Regeneration_Menu(ChatDialogHandlerBase next) : base(next, "Material_Regeneration_Menu")
        {
            this.Parents.Add("welcome_entrepreneur");
            this.Route = "\\regeneracionmaterial";
        }

        /// <inheritdoc/>
        public override string Execute(ChatDialogSelector selector)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Menu para saber que materiales se regeneran . \n");
            builder.Append("Desde este menu puede realizar las\n");
            builder.Append("siguientes operaciones:\n\n");
            builder.Append(GetTextToPrintListMaterialRegeneration());
            builder.Append("\\volver : Volver al menú principal.\n");
            return builder.ToString();
        }
        /// <summary>
        /// Listar todos los materiales y la compañia que los vende.
        /// </summary>
        /// <returns>Una string con el id, nombre del mat y el nombre de la compañia que lo vende</returns>
        public string GetTextToPrintListMaterialRegeneration()
        {
            StringBuilder builder = new StringBuilder();
            foreach(CompanyMaterial xMat in this.DatMgr.CompanyMaterial.Items)
            {
                builder.Append("Identificador -" + xMat.Id + ", el nombre del material " + xMat.Name + ", la compañia que lo vende es " + this.DatMgr.Company.GetById(xMat.CompanyId).Name + " \n");
            }
            return builder.ToString();
        }

    }
}
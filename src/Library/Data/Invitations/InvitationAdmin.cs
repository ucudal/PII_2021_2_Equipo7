using System;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Invitaciones.
    /// </summary>
    public class InvitationAdmin: DataAdmin<Invitation>
    {
        /// <summary>
        /// Obtener la invitacion a 
        /// partir de su codigo.
        /// </summary>
        /// <param name="pCode">
        /// Codigo de la invitacion.
        /// </param>
        /// <returns></returns>
        public Invitation GetByCode(string pCode)
        {
            ReadOnlyCollection<Invitation> invites = this.Items;
            foreach (Invitation inv in invites)
            {
                if (inv.Code == pCode)
                {
                    return inv.Clone();
                }
            }
            return null;
        }

        /// <summary>
        /// Verifica si una invitacion
        /// pertenece al tipo sugerido.
        /// </summary>
        /// <param name="code">
        /// Codigo de la invitacion a
        /// verificar.
        /// </param>
        /// <param name="type">
        /// Tipo de invitacion contra
        /// el cual comparar.
        /// </param>
        /// <returns>
        /// Valor booleano representado
        /// si la invitacion pertenece
        /// al tipo.
        /// </returns>
        public bool GetInvitationIsOfType(string code, RegistrationType type)
        {
            ReadOnlyCollection<Invitation> invites = this.Items;
            foreach (Invitation inv in invites)
            {
                if (inv.Code == code)
                {
                    return inv.Type == type;
                }
            }
            return false;

        }

        

        /// <summary>
        /// Actualizar una invitacion con un
        /// nuevo codigo de invitacion generado
        /// dinamicamente a partir de la fecha
        /// actual y el Id.
        /// </summary>
        /// <param name="inviteId">
        /// Id de la invitacion para la cual se
        /// busca generar un nuevo codigo.
        /// </param>
        public void GenerateNewInviteCode(int inviteId)
        {
            Invitation invite = this.GetById(inviteId);
            
            if (invite is not null)
            {
                DateTime now = DateTime.Now;
                StringBuilder builder = new StringBuilder();
                builder.Append(now.Year.ToString("D4"));
                builder.Append(now.DayOfYear.ToString("D3"));
                builder.Append("-");
                switch (invite.Type)
                {
                    case RegistrationType.CopmanyNew:
                        builder.Append("CN-");
                        break;
                    case RegistrationType.CompanyJoin:
                        builder.Append("CJ-");
                        break;
                    case RegistrationType.EntrepreneurNew:
                        builder.Append("EN-");
                        break;
                    case RegistrationType.SystemAdminJoin:
                        builder.Append("SJ-");
                        break;
                    default:
                        builder.Append("XX-");
                        break;
                }
                string idTransformed = inviteId.ToString().PadLeft(8, '0');
                idTransformed = idTransformed.Substring(idTransformed.Length - 5);
                builder.Append(idTransformed);

                invite.Code = builder.ToString();
                this.Update(invite);
            }
        }
    }
}

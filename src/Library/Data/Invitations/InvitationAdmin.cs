using System;
using System.Collections.Generic;

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
    }
}

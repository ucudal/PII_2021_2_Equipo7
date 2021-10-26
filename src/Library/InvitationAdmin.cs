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
        /// Obetener la invitacion a partir de su codigo
        /// </summary>
        /// <param name="pCode">Codigo de la invtacion</param>
        /// <returns></returns>
        public Invitation GetByCode(string pCode)
        {
            return this.Items.Find(obj=>obj.Code==pCode);
        }
    }
}

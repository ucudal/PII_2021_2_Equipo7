// -----------------------------------------------------------------------
// <copyright file="InsertInvitationData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertInvitationData : SearchData
    {
        private Invitation invitation;
        private RegistrationType registrationtype;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertInvitationData"/>.
        /// </summary>
        public InsertInvitationData()
            : base()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertInvitationData"/>.
        /// </summary>
        /// <param name="searchResults">buscar resultados.</param>
        /// <param name="searchPageContext">contexto de pag.</param>
        /// <param name="searchPageRoute">ruta fde pag.</param>
        /// <param name="pageItemCount">items de pag.</param>
        public InsertInvitationData(IReadOnlyCollection<int> searchResults, string searchPageContext, string searchPageRoute, int pageItemCount = 6)
            : base(searchResults, searchPageContext, searchPageRoute, pageItemCount)
        {
        }

        /// <summary>
        /// invitacion del usuario.
        /// </summary>
        public Invitation Invitation { get => this.invitation; set => this.invitation = value; }

        /// <summary>
        /// tipo de registro del usuario.
        /// </summary>
        public RegistrationType RegistrationType { get => this.registrationtype; set => this.registrationtype = value; }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            DataManager dataManager = new DataManager();
            Invitation inv = dataManager.Invitation.New();
            inv.Type = this.registrationtype;
            inv.CompanyId = this.Invitation.CompanyId;
            inv.Used = false;
            inv.ValidAfter = DateTime.Now;
            inv.ValidBefore = DateTime.Now.AddMonths(1);
            int id = dataManager.Invitation.Insert(inv);
            if (id == 0)
            {
                return false;
            }

            dataManager.Invitation.GenerateNewInviteCode(id);

            return true;
      }
    }
}
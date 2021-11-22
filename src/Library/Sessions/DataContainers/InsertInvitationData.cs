// -----------------------------------------------------------------------
// <copyright file="InsertInvitationData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertInvitationData : ActivityData
    {
        private Invitation invitation;
        private RegistrationType registrationtype;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertInvitationData"/>.
        /// </summary>
        public InsertInvitationData()
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
    }
}
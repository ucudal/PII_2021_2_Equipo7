// -----------------------------------------------------------------------
// <copyright file="ErasePublicationData.cs" company="Universidad Católica del Uruguay">
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
    public class ErasePublicationData : ActivityData
    {
        private CompanyMaterial companyMaterial;
        private Publication publication;
        private DataManager dataManager = new DataManager();
        private int companyId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertPublicationData"/>.
        /// </summary>
        public ErasePublicationData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial; set => this.companyMaterial = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public Publication Publication { get => this.publication; set => this.publication = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public int CompanyId { get => this.companyId; set => this.companyId = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        /// <returns>boleano de publication.</returns>
        public override bool RunTask()
        {
            bool retorno = false;
            if (this.dataManager.Publication.Delete(this.Publication.Id))
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
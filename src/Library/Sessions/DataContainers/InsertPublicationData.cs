// -----------------------------------------------------------------------
// <copyright file="InsertPublicationData.cs" company="Universidad Católica del Uruguay">
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
    public class InsertPublicationData : ActivityData
    {
        private CompanyMaterial companyMaterial;
        private Publication publication;
        private DataManager dataManager;
        private int companyId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertPublicationData"/>.
        /// </summary>
        public InsertPublicationData()
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
        /// <returns>valor del retorno .</returns>
        public override bool RunTask()
        {
            bool xretorno = false;
            Publication xPubl = this.Publication;
            xPubl.CompanyMaterialId = this.CompanyMaterial.Id;
            xPubl.CompanyId = this.dataManager.Company.GetById(this.companyId).Id;
            int idPub = this.dataManager.Publication.Insert(xPubl);
            if (idPub != 0)
            {
                xretorno = true;
            }

            return xretorno;
        }
    }
}
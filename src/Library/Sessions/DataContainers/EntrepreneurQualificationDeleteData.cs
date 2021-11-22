// -----------------------------------------------------------------------
// <copyright file="EntrepreneurQualificationDeleteData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Informacion de una busqueda.
    /// </summary>
    public class EntrepreneurQualificationDeleteData : ActivityData
    {
        private int entrepreneurQualificationId;
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntrepreneurQualificationDeleteData"/> class.
        /// </summary>
        public EntrepreneurQualificationDeleteData()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntrepreneurQualificationDeleteData"/>.
        /// </summary>
        /// <param name="entrepreneurQualificationId">
        /// Id del emprendedor a eliminar.
        /// </param>
        public EntrepreneurQualificationDeleteData(int entrepreneurQualificationId)
        {
            this.entrepreneurQualificationId = entrepreneurQualificationId;
        }

        /// <summary>
        /// Acceso protegido al contenedor de administradores.
        /// </summary>
        protected DataManager DatMgr
        {
            get => this.datMgr;
            set => this.datMgr = value;
        }

        /// <inheritdoc/>
        public override bool RunTask()
        {
            bool isOk = this.DatMgr.EntrepreneurQualification.Delete(this.entrepreneurQualificationId);
            return isOk;
        }
    }
}
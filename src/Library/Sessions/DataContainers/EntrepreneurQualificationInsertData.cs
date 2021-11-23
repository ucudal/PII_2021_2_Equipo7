// -----------------------------------------------------------------------
// <copyright file="EntrepreneurQualificationInsertData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Informacion de una busqueda.
    /// </summary>
    public class EntrepreneurQualificationInsertData : ActivityData
    {
        private int qualificationId;
        private int entrepreneurId;
        private Uri documentUri;
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntrepreneurQualificationInsertData"/> class.
        /// </summary>
        public EntrepreneurQualificationInsertData()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntrepreneurQualificationDeleteData"/>.
        /// </summary>
        /// <param name="qualificationId">
        /// Id de la habilitacion a agregar.
        /// </param>
        /// <param name="entrepreneurId">
        /// Id del emprendedor al cual agregar
        /// la habilitacion.
        /// </param>
        public EntrepreneurQualificationInsertData(int qualificationId, int entrepreneurId)
        {
            this.qualificationId = qualificationId;
            this.entrepreneurId = entrepreneurId;
        }

        /// <summary>
        /// Uri del documento de la habilitacion.
        /// </summary>
        public Uri DocumentUri
        {
            get => this.documentUri;
            set => this.documentUri = value;
        }

        /// <summary>
        /// Id de la habilitacion a usar.
        /// </summary>
        public int QualificationId { get => this.qualificationId; }

        /// <summary>
        /// Id del emprendedor que usara la habilitacion.
        /// </summary>
        public int EntrepreneurId { get => this.entrepreneurId; }

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
            EntrepreneurQualification qualification = this.DatMgr.EntrepreneurQualification.New();
            qualification.EntrepreneurId = this.entrepreneurId;
            qualification.QualificationId = this.qualificationId;
            qualification.DocumentUri = this.documentUri;
            int entreQualId = this.DatMgr.EntrepreneurQualification.Insert(qualification);

            return entreQualId != 0;
        }
    }
}
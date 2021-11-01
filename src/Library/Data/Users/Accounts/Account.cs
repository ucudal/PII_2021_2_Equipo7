using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// la clase account maneja las cuentas de lso usuarios
    /// </summary>
    public class Account: IManagableData<Account>
    {
        private int id;
        private bool deleted;
        private int userId;
        private MessagingService service;
        private string codeInService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Account"/>.
        /// </summary>
        [JsonConstructor]
        public Account()
        {
            this.Id = 0;
            this.deleted = false;
        }

        /// <inheritdoc/>
        public int Id 
        { 
            get => this.id; 
            set => this.id = value; 
        }

        /// <inheritdoc/>
        public bool Deleted 
        { 
            get => this.deleted; 
            set => this.deleted = value; 
        }

        /// <summary>
        /// Id del usuario asociado
        /// a la cuenta
        /// </summary>
        public int UserId 
        { 
            get => this.userId; 
            set => this.userId = value; 
        }

        /// <summary>
        /// Servicio de mensajeria
        /// asociado a la cuenta.
        /// </summary>
        public MessagingService Service 
        { 
            get => this.service; 
            set => this.service = value; 
        }

        /// <summary>
        /// Identificador de la
        /// cuenta en el servicio
        /// de mensajeria asociado
        /// </summary>
        public string CodeInService 
        { 
            get => this.codeInService; 
            set => this.codeInService = value; 
        }

        /// <inheritdoc/>
        public Account Clone()
        {
            Account acc = new Account();
            acc.LoadFromJson(this.ConvertToJson());
            return acc;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Account acc = JsonSerializer.Deserialize<Account>(json);
            this.Id = acc.Id;
            this.Deleted = acc.Deleted;
            this.UserId = acc.UserId;
            this.Service = acc.Service;
            this.CodeInService = acc.CodeInService;
        }
    }
}
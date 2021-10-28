using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada para conocer los datos de la invitacion
    /// </summary>
    public class Invitation:IManagableData<Invitation>
    {
        /// <summary>
        /// Identificador de cada Invitacion
        /// </summary>
        public int Id{get; set;}

        /// <summary>
        /// Codigo de la invitacion
        /// </summary>
        /// <value>Almacenamos el codigo de la invitacion en un string</value>
        public string Code{get;set;}

        /// <summary>
        /// Tipo de la invitacion
        /// </summary>
        /// <value>Almacenamos que tipo de invitacion es. Si es una invitación a una empresa ya existente o a una empresa nueva o a un emprendedor o a un admin del sistema</value>
        public RegistrationType Type{get;set;}

        /// <summary>
        /// Fecha desde cuando es valida la invitacion
        /// </summary>
        public DateTime ValidAfter{get;set;}

        /// <summary>
        /// Fecha hasta cuando es valida la invitacion
        /// </summary>
        public DateTime ValidBefore{get;set;}

        /// <summary>
        /// Id de la company a unirse
        /// </summary>
        /// <value>En caso de unirnos a una company, nos unimos segun su id. En caso de no unirse a ninguna empresa, se alamacena 0</value>
        public int CompanyId{get;set;}

        /// <summary>
        /// Si la invitacion esta utilizada
        /// </summary>
        /// <value>En caso de que la invitacion haya sido utilizada entonces used=true. En caso contrario used=false</value>
        public bool Used{get;set;}

        /// <summary>
        /// Si la invitacion esta eliminada
        /// </summary>
        /// <value>En caso de que la invitacion haya sido eliminada entonces deleted=true. En caso contrario deleted=false</value>
        public bool Deleted{get; set;}

        [JsonConstructor]
        public Invitation(int id, string code,RegistrationType type,DateTime validAfter,DateTime validBefore,int companyId,bool used,bool deleted)
        {
            this.Id=id;
            this.Code=code;
            this.Type=type;
            this.ValidAfter=validAfter;
            this.ValidBefore=validBefore;
            this.CompanyId=companyId;
            this.Used=used;
            this.Deleted=deleted;
        }
        public Invitation()
        {
            
        }

        public void LoadFromJson(string json)
        {
            Invitation invitation=JsonSerializer.Deserialize<Invitation>(json);
            this.Id=invitation.Id;
            this.Code=invitation.Code;
            this.Type=invitation.Type;
            this.ValidAfter=invitation.ValidAfter;
            this.ValidBefore=invitation.ValidBefore;
            this.CompanyId=invitation.CompanyId;
            this.Used=invitation.Used;
            this.Deleted=invitation.Deleted;
        }
            
        public Invitation Clone()
        {
            Invitation invitation=new Invitation();
            invitation.LoadFromJson(this.ConvertToJson());
            return invitation;
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
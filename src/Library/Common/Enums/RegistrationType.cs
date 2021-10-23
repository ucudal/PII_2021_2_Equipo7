namespace Library
{
    /// <summary>
    /// Enumerable que lista los distintos tipos
    /// de procesos de registro para los usuarios.
    /// </summary>
    public enum RegistrationType
    {
        ///<summary>Registro de un nuevo emprendedor.</summary>
        EntrepreneurNew,
        ///<summary>Registro de una nueva empresa.</summary>
        CopmanyNew,
        ///<summary>Registro de usuario administrador para una empresa.</summary>
        CompanyJoin,
        ///<summary>Registro de usuario administrador de la plataforma.</summary>
        SystemAdminJoin
        
    }
}
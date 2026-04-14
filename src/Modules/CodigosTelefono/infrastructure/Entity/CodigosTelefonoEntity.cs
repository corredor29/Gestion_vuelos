using System;

namespace Gestion_vuelos.src.Modules.CodigosTelefono.infrastructure.Entity;

public class CodigosTelefonoEntity
{
    public Guid Id {get; set;} 
    public string Country_code {get; set;} = string.Empty;
    public string Pais {get; set;} = string.Empty;
}

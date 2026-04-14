using System;

namespace Gestion_vuelos.src.Modules.DominiosEmail.infrastructure.Entity;

public class DominiosEmailEntity
{
    public Guid Id {get; set;}
    public string Dominio {get; set;} = null!;
}

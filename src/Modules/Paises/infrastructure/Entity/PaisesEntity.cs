using System;

namespace Gestion_vuelos.src.Modules.Paises.infrastructure.Entity;

public class PaisesEntity
{
    public Guid Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string CodigoIso { get; set; } = null!;
}

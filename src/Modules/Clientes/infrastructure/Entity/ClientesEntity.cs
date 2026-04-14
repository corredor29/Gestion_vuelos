using System;
using Gestion_vuelos.src.Modules.TipoDocumento.infrastructure.Entity;

namespace Gestion_vuelos.src.Modules.Clientes.infrastructure.Entity;

public class ClientesEntity
{
    public Guid Id {get; set;}
    public Guid Tipo_Documento_Id {get; set;}  
    public string NumeroDocumento { get; set; } = null!;
    public string Name {get; set;} = string.Empty;
    public string Last_name {get; set;} = string.Empty;
    public TipoDocumentoEntity TipoDocumento { get; set; } = null!;
}

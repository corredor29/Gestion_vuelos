namespace Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

public sealed record AirlineActive
{
    public bool Value { get; }

    private AirlineActive(bool value) => Value = value;

    public static AirlineActive Create(bool value) => new(value);
}
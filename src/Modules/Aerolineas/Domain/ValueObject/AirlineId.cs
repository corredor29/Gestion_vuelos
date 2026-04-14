namespace Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

public sealed record AirlineId
{
    public int Value { get; }

    private AirlineId(int value) => Value = value;

    public static AirlineId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la aerolínea es inválido.", nameof(value));

        return new AirlineId(value);
    }
}
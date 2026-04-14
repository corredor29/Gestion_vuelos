namespace Gestion_vuelos.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportId
{
    public int Value { get; }

    private AirportId(int value) => Value = value;

    public static AirportId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de aeropuerto es inválido.", nameof(value));

        return new AirportId(value);
    }
}
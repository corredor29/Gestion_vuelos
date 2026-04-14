namespace Gestion_vuelos.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportIataCode
{
    public string Value { get; }

    private AirportIataCode(string value) => Value = value;

    public static AirportIataCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código IATA de aeropuerto no puede estar vacío.", nameof(value));

        if (value.Length != 3)
            throw new ArgumentException("El código IATA de aeropuerto debe tener 3 caracteres.", nameof(value));

        return new AirportIataCode(value.Trim().ToUpperInvariant());
    }

    public override string ToString() => Value;
}

namespace Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

public sealed record AirlineIataCode
{
    public string Value { get; }

    private AirlineIataCode(string value) => Value = value;

    public static AirlineIataCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código IATA de aerolínea no puede estar vacío.", nameof(value));

        if (value.Length != 3)
            throw new ArgumentException("El código IATA de aerolínea debe tener 3 caracteres.", nameof(value));

        return new AirlineIataCode(value.Trim().ToUpperInvariant());
    }

    public override string ToString() => Value;
}
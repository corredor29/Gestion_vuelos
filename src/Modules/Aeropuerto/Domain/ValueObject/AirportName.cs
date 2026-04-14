namespace Gestion_vuelos.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportName
{
    public string Value { get; }

    private AirportName(string value) => Value = value;

    public static AirportName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de aeropuerto no puede estar vacío.", nameof(value));

        if (value.Length > 150)
            throw new ArgumentException("El nombre no puede tener más de 150 caracteres.", nameof(value));

        if (value.All(char.IsDigit))
            throw new ArgumentException("El nombre no puede ser solo números.", nameof(value));

        if (!value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-' || c == '&'))
            throw new ArgumentException("El nombre solo puede contener letras, espacios, puntos, guiones y '&'.", nameof(value));

        return new AirportName(value.Trim());
    }

    public override string ToString() => Value;
}   
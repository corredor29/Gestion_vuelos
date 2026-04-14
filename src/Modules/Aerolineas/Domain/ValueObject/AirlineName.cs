namespace Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

public sealed record AirlineName
{
    public string Value { get; }

    private AirlineName(string value) => Value = value;

    public static AirlineName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la aerolínea no puede estar vacío.", nameof(value));

        if (value.Length > 150)
            throw new ArgumentException("El nombre no puede tener más de 150 caracteres.", nameof(value));

        if (value.All(char.IsDigit))
            throw new ArgumentException("El nombre no puede ser solo números.", nameof(value));

        if (!value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-' || c == '&'))
            throw new ArgumentException("El nombre solo puede contener letras, espacios, puntos, guiones y '&'.", nameof(value));

        return new AirlineName(value.Trim());
    }

    public override string ToString() => Value;
}
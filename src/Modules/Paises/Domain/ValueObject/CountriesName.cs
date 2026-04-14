namespace Gestion_vuelos.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryName
{
    public string Value { get; }

    private CountryName(string value) => Value = value;

    public static CountryName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de país no puede estar vacío.", nameof(value));

        if (value.Length > 150)
            throw new ArgumentException("El nombre no puede tener más de 150 caracteres.", nameof(value));

        if (value.All(char.IsDigit))
            throw new ArgumentException("El nombre no puede ser solo números.", nameof(value));

        if (!value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-' || c == '&'))
            throw new ArgumentException("El nombre solo puede contener letras, espacios, puntos, guiones y '&'.", nameof(value));

        return new CountryName(value.Trim());
    }

    public override string ToString() => Value;
}
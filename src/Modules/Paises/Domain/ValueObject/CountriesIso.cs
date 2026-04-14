namespace Gestion_vuelos.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryIsoCode
{
    public string Value { get; }

    private CountryIsoCode(string value) => Value = value;

    public static CountryIsoCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código ISO no puede estar vacío.", nameof(value));

        if (value.Length != 3)
            throw new ArgumentException("El código ISO debe tener exactamente 3 caracteres.", nameof(value));

        return new CountryIsoCode(value.Trim().ToUpperInvariant());
    }

    public override string ToString() => Value;
}
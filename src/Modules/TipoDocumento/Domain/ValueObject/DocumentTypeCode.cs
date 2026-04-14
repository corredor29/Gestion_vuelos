namespace Gestion_vuelos.src.Modules.DocumentTypes.Domain.ValueObject;

public sealed record DocumentTypeCode
{
    public string Value { get; }

    private DocumentTypeCode(string value) => Value = value;

    public static DocumentTypeCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código de tipo de documento no puede estar vacío.", nameof(value));

        if (value.Length is < 1 or > 10)
            throw new ArgumentException("El código debe tener entre 1 y 10 caracteres.", nameof(value));

        if (!value.All(char.IsLetter))
            throw new ArgumentException("El código solo puede contener letras (sin números ni símbolos).", nameof(value));

        return new DocumentTypeCode(value.Trim().ToUpperInvariant());
    }

    public override string ToString() => Value;
}
namespace Gestion_vuelos.src.Modules.DocumentTypes.Domain.ValueObject;

public sealed record DocumentTypeName
{
    public string Value { get; }

    private DocumentTypeName(string value) => Value = value;

    public static DocumentTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del tipo de documento no puede estar vacío.", nameof(value));

        if (value.Length > 150)
            throw new ArgumentException("El nombre no puede tener más de 150 caracteres.", nameof(value));

        if (value.All(char.IsDigit))
            throw new ArgumentException("El nombre no puede ser solo números.", nameof(value));

        if (!value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '-' || c == '&'))
            throw new ArgumentException("El nombre solo puede contener letras, espacios, puntos, guiones y '&'.", nameof(value));

        return new DocumentTypeName(value.Trim());
    }

    public override string ToString() => Value;
}
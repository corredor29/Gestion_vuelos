namespace Gestion_vuelos.src.Modules.DocumentTypes.Domain.ValueObject;

public sealed record DocumentTypeId
{
    public int Value { get; }

    private DocumentTypeId(int value) => Value = value;

    public static DocumentTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del tipo de documento es inválido.", nameof(value));

        return new DocumentTypeId(value);
    }
}
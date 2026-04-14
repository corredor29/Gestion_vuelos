namespace Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

public sealed record OriginCountryId
{
    public int Value { get; }

    private OriginCountryId(int value) => Value = value;

    public static OriginCountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de país de origen es inválido.", nameof(value));

        return new OriginCountryId(value);
    }
}
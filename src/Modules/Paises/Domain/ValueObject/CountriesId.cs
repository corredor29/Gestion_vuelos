namespace Gestion_vuelos.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryId
{
    public int Value { get; }

    private CountryId(int value) => Value = value;

    public static CountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de país es inválido.", nameof(value));

        return new CountryId(value);
    }
}
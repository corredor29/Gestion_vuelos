namespace Gestion_vuelos.src.Modules.Cities.Domain.ValueObject;

public sealed record CityId
{
    public int Value { get; }

    private CityId(int value) => Value = value;

    public static CityId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la ciudad es inválido.", nameof(value));

        return new CityId(value);
    }
}
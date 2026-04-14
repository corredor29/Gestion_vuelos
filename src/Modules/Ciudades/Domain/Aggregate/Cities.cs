using Gestion_vuelos.src.Modules.Cities.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Cities.Domain.Aggregate;

public sealed class City
{
    public CityId Id { get; private set; }

    public CityName Name { get; private set; }
    public CityIsoCode IsoCode { get; private set; }

    private City() { }

    private City(
        CityId id,
        CityName name,
        CityIsoCode isoCode)
    {
        Id = id;
        Name = name;
        IsoCode = isoCode;
    }

    public static City Create(int id, string name, string isoCode)
    {
        return new City(
            CityId.Create(id),
            CityName.Create(name),
            CityIsoCode.Create(isoCode)
        );
    }

    public void Update(string name, string isoCode)
    {
        Name = CityName.Create(name);
        IsoCode = CityIsoCode.Create(isoCode);
    }
}
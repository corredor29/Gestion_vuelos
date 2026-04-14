using Gestion_vuelos.src.Modules.Countries.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Countries.Domain.Aggregate;

public sealed class Country
{
    public CountryId Id { get; private set; }

    public CountryName Name { get; private set; }
    public CountryIsoCode IsoCode { get; private set; }

    private Country() { }

    private Country(
        CountryId id,
        CountryName name,
        CountryIsoCode isoCode)
    {
        Id = id;
        Name = name;
        IsoCode = isoCode;
    }


    public static Country Create(int id, string name, string isoCode)
    {
        return new Country(
            CountryId.Create(id),
            CountryName.Create(name),
            CountryIsoCode.Create(isoCode)
        );
    }

    public void Update(string name, string isoCode)
    {
        Name = CountryName.Create(name);
        IsoCode = CountryIsoCode.Create(isoCode);
    }
}
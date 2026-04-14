using Gestion_vuelos.src.Modules.Airports.Domain.ValueObject;
using Gestion_vuelos.src.Modules.Cities.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Airports.Domain.Aggregate;

public sealed class Airport
{
    public AirportId Id { get; private set; }

    public AirportName Name { get; private set; }
    public AirportIataCode IataCode { get; private set; }

    // FK a City como VO
    public CityId CityId { get; private set; }

    private Airport() { }

    private Airport(
        AirportId id,
        AirportName name,
        AirportIataCode iataCode,
        CityId cityId)
    {
        Id = id;
        Name = name;
        IataCode = iataCode;
        CityId = cityId;
    }

    public static Airport Create(
        int id,
        string name,
        string iataCode,
        int cityId)
    {
        return new Airport(
            AirportId.Create(id),
            AirportName.Create(name),
            AirportIataCode.Create(iataCode),
            CityId.Create(cityId)
        );
    }

    public void Update(
        string name,
        string iataCode,
        int cityId)
    {
        Name = AirportName.Create(name);
        IataCode = AirportIataCode.Create(iataCode);
        CityId = CityId.Create(cityId);
    }
}
using Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Airlines.Domain.Aggregate;

public sealed class Airline
{
    public AirlineId Id { get; private set; }

    public AirlineName Name { get; private set; }
    public AirlineIataCode IataCode { get; private set; }

    // FK como VO propio del módulo
    public OriginCountryId OriginCountryId { get; private set; }

    // Si quieres usar VO también aquí, cambia a AirlineActive
    public bool IsActive { get; private set; }

    private Airline() { }

    private Airline(
        AirlineId id,
        AirlineName name,
        AirlineIataCode iataCode,
        OriginCountryId originCountryId,
        bool isActive)
    {
        Id = id;
        Name = name;
        IataCode = iataCode;
        OriginCountryId = originCountryId;
        IsActive = isActive;
    }

    public static Airline Create(
        int id,
        string name,
        string iataCode,
        int originCountryId,
        bool isActive = true)
    {
        return new Airline(
            AirlineId.Create(id),
            AirlineName.Create(name),
            AirlineIataCode.Create(iataCode),
            OriginCountryId.Create(originCountryId),
            isActive
        );
    }

    public void ChangeName(string newName)
    {
        Name = AirlineName.Create(newName);
    }

    public void ChangeOriginCountry(int newOriginCountryId)
    {
        OriginCountryId = OriginCountryId.Create(newOriginCountryId);
    }

    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("La aerolínea ya está activa.");

        IsActive = true;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("La aerolínea ya está desactivada.");

        IsActive = false;
    }
}
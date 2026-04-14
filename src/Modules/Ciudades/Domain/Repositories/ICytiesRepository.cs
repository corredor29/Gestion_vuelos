using Gestion_vuelos.src.Modules.Cities.Domain.Aggregate;
using Gestion_vuelos.src.Modules.Cities.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Cities.Domain.Repositories;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(CityId id, CancellationToken cancellationToken = default);
    Task<City?> GetByIsoCodeAsync(CityIsoCode isoCode, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<City>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(City city, CancellationToken cancellationToken = default);
    Task UpdateAsync(City city, CancellationToken cancellationToken = default);
    Task DeleteAsync(City city, CancellationToken cancellationToken = default);
}
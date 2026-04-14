using Gestion_vuelos.src.Modules.Countries.Domain.Aggregate;
using Gestion_vuelos.src.Modules.Countries.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Countries.Domain.Repositories;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(CountryId id, CancellationToken cancellationToken = default);
    Task<Country?> GetByIsoCodeAsync(CountryIsoCode isoCode, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Country country, CancellationToken cancellationToken = default);
    Task UpdateAsync(Country country, CancellationToken cancellationToken = default);
    Task DeleteAsync(Country country, CancellationToken cancellationToken = default);
}
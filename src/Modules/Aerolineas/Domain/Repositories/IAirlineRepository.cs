using Gestion_vuelos.src.Modules.Airlines.Domain.Aggregate;
using Gestion_vuelos.src.Modules.Airlines.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Airlines.Domain.Repository;

public interface IAirlineRepository
{
    Task<Airline?> GetByIdAsync(AirlineId id, CancellationToken cancellationToken = default);
    Task<Airline?> GetByIataCodeAsync(AirlineIataCode iataCode, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Airline>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Airline airline, CancellationToken cancellationToken = default);
    Task UpdateAsync(Airline airline, CancellationToken cancellationToken = default);
    Task DeleteAsync(Airline airline, CancellationToken cancellationToken = default);
}
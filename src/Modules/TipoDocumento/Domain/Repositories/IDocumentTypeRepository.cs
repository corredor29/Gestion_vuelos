using Gestion_vuelos.src.Modules.DocumentTypes.Domain.Aggregate;
using Gestion_vuelos.src.Modules.DocumentTypes.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.DocumentTypes.Domain.Repositories;

public interface IDocumentTypeRepository
{
    Task<DocumentType?> GetByIdAsync(DocumentTypeId id, CancellationToken cancellationToken = default);
    Task<DocumentType?> GetByCodeAsync(DocumentTypeCode code, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DocumentType>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(DocumentType documentType, CancellationToken cancellationToken = default);
    Task UpdateAsync(DocumentType documentType, CancellationToken cancellationToken = default);
    Task DeleteAsync(DocumentType documentType, CancellationToken cancellationToken = default);
}
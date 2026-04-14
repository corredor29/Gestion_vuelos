using Gestion_vuelos.src.Modules.DocumentTypes.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.DocumentTypes.Domain.Aggregate;

public sealed class DocumentType
{
    public DocumentTypeId Id { get; private set; }
    public DocumentTypeName Name { get; private set; }
    public DocumentTypeCode Code { get; private set; }

    private DocumentType() { }

    private DocumentType(
        DocumentTypeId id,
        DocumentTypeName name,
        DocumentTypeCode code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public static DocumentType Create(int id, string name, string code)
    {
        return new DocumentType(
            DocumentTypeId.Create(id),
            DocumentTypeName.Create(name),
            DocumentTypeCode.Create(code)
        );
    }

    public void Update(string name, string code)
    {
        Name = DocumentTypeName.Create(name);
        Code = DocumentTypeCode.Create(code);
    }
}
using GscareApiAspNetCore.Domain.Enums;
using System.Xml.Linq;

namespace GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
public interface IEmployeeDocumentRepository
{
    Task<string?> GetDocumentByEmployeeId(long employeeId, DocumentType documentType);
    Task SaveDocument(long employeeId, DocumentType documentType, string documentFileName);
    Task DeleteDocument(long employeeId, DocumentType documentType);
}